using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RollingRecord
{
    internal class ReadRecord
    {
        static int firstRow = 4;
        static int nameRow = 3;
        public void openExcel(string fullPath)
        {
            string resSql = "";
            FileStream fs = File.Open(fullPath, FileMode.Open, FileAccess.Read);

            IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);

            DataSet result = reader.AsDataSet();
            for (int i = 0; i < result.Tables.Count; i++)
            {
                DataTable table = result.Tables[i];
                //得到其中一张表的数据
                //得到其中一行的数据
                //DataRow row = table.Rows[0];
                //得到行中某一列的 信息
                //Debug.Log(row[1].ToString()); 
                double sleepTime = 0;
                string[] nameList = new string[table.Columns.Count - 1];
                 /*{
                    "A",
                    "B",
                    "C",
                    "D",
                    "E",
                    "F",
                    "G",
                    "H",
                    "I",
                    "J",
                    "K",
                    "L",
                    "M",
                    "N",
                    "O",
                    "P",
                    "Q",
                    "R",
                    "S",
                    "T",
                    "U",
                    "V",
                    "W",
                    "X",
                };
                */
                
                
                for (int k = 1; k < table.Columns.Count; k++)
                {
                    nameList[k-1] = table.Rows[nameRow][k].ToString();
                }
                
                
                double lastTime = 0;
                InfluxDBClient client = new InfluxDBClient();
                for (int j = firstRow; j < table.Rows.Count; j++)
                {
                    //DataRow dataRow = dataTable.NewRow();
                    var time = Convert.ToDouble(table.Rows[j][0].ToString());
                    sleepTime = time - lastTime;
                    lastTime = time;
                    Console.WriteLine("sleepTime:" + sleepTime);
                    
                    var rowSql = "testRecord,name=20230107-0341.xls ";
                    for (int k = 1; k < table.Columns.Count; k++)
                    {
                        rowSql += nameList[k-1] + "=" + Convert.ToDouble(table.Rows[j][k].ToString()) ;
                        if (k < table.Columns.Count - 1)
                        {
                            rowSql += ",";
                        }
                    }
                    //resSql += rowSql;
                    
                    var res = client.Write("test", rowSql);
                    Thread.Sleep((int)(sleepTime * 1000));
                    //Console.WriteLine(res);
                    //dataTable.Rows.Add(dataRow);
                }
            }
        }
    }
}

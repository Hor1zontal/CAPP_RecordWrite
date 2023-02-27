using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RollingRecord
{
    internal static class Program
    {
        //文件路径为根路径下的record，根据自己的文件路径修改DocumentPath路径
        public static string DocumentPath = "D:\\project\\c#\\CAPP_RecordWrite\\RollingRecord\\record";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>

        static void Main()
        {

            ReadRecord readRecord = new ReadRecord();
            readRecord.openExcel(DocumentPath);
            //test();
        }
        static public void test()
        {
            InfluxDBClient client = new InfluxDBClient();
            string sql = "";
            var result = "";
            //sql = "CREATE DATABASE mydb";
            //result = client.Query("mydb", sql);
            //Console.WriteLine(result);
            //sql = "testRecord,A=1225.15 B=315.48 C=769.72 D=2903.14 E=2899.62 F=-2.67 G=-0.06 H=-74.57 I=-1.74 J=-60.00 K=-14.52 L=1170.58 M=1184.86 N=5.20 O=7.34 P=2.98 Q=3.85 R=2.11 S=84.71 T=0.00 U=88.09 V=88.09 W=7.19 X=12.98";
            sql = "testTable,name=测试,count=1.0 value=10";
            result = client.Write("test", sql);
            Console.WriteLine(result);

            sql = "select * from testTable";
            result = client.Query("test", sql);
            Console.WriteLine(result);
        }
    }
}

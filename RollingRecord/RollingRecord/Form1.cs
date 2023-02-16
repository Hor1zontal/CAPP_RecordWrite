using ExcelDataReader;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace RollingRecord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ReadRecordLine();
            //test();
        }
        private void test()
        {
            InfluxDBClient client = new InfluxDBClient();
            string sql = "";
            var result = "";
            //sql = "CREATE DATABASE mydb";
            //result = client.Query("mydb", sql);
            //Console.WriteLine(result);
            //sql = "testRecord,A=1225.15 B=315.48 C=769.72 D=2903.14 E=2899.62 F=-2.67 G=-0.06 H=-74.57 I=-1.74 J=-60.00 K=-14.52 L=1170.58 M=1184.86 N=5.20 O=7.34 P=2.98 Q=3.85 R=2.11 S=84.71 T=0.00 U=88.09 V=88.09 W=7.19 X=12.98";
            sql = "testTable,name=aaa,count=1.0 value=10";
            result = client.Write("test", sql);
            Console.WriteLine(result);

            sql = "select * from testTable";
            result = client.Query("test", sql);
            Console.WriteLine(result);
        }

        public void ReadRecordLine()
        {
            //ReadRecord.openExcel("D:\\Documents\\20230107-0341.xls");
        }

    }
}

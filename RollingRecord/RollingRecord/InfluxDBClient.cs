namespace RollingRecord
{
    internal class InfluxDBClient
    {
        string _baseAddress = "http://127.0.0.1:8086";
        string _username = "admin";
        string _password = "password";


        /// <summary>
        /// ��
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sql">
        /// sql = "CREATE DATABASE mydb";
        /// sql = "select * from test";
        /// </param>
        /// <returns></returns>
        public string Query(string database, string sql)
        {
            string pathAndQuery = string.Format("/query?db={0}&q={1}", database, sql);
            string url = _baseAddress + pathAndQuery;

            string result = HttpHelper.Get(url, _username, _password);
            return result;
        }




        /// <summary>
        /// д
        /// </summary>
        /// <param name="database"></param>
        /// <param name="sql">
        /// string sql = "test,name=����,count=1 value=10";
        /// �����test   ����name   ��count,value
        /// </param>
        public string Write(string database, string sql)
        {
            string pathAndQuery = string.Format("/write?db={0}&precision=s", database);
            string url = _baseAddress + pathAndQuery;

            string result = HttpHelper.Post(url, sql, _username, _password);
            return result;
        }
    }
}

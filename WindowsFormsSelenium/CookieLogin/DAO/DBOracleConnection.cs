using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CookieLogin.DAO
{
    class DBOracleConnection
    {
        public static String getConnectionString()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string host = appSettings["oracle_host"] ?? "Not Found";
                string username = appSettings["oracle_username"] ?? "Not Found";
                string password = appSettings["oracle_password"] ?? "Not Found";
                string servicename = appSettings["oracle_servicename"] ?? "Not Found";
                //return "Server=" + host + ";Database=" + db + ";Uid=" + username + ";Pwd=" + password + ";Port=3306; Charset=utf8;";
                return $"Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = {host})(PORT = 1521))(CONNECT_DATA = (SERVICE_NAME = {servicename}))); User Id = {username}; Password = {password}";
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error reading app settings");
                return "error";
            }
        } 

        public static void ExecuteNonQuery(string query)
        {
            string connection_string = getConnectionString();
            OracleConnection conn = new OracleConnection(connection_string);
           
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                cmd.CommandText = query;
               // cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch(Exception)
            {

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Dispose();
                }
            }
        }
    }
}

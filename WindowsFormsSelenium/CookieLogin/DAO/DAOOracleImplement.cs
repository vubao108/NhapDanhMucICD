using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieLogin.DAO
{
    class DAOOracleImplement
    {
       
        public static void insert_new_vanban_to_dm(string P_TRICHYEU
                                                    , string P_SOHIEU
                                                    , string P_NGAYDEN
                                                    , string P_NGAYBANHANH
                                                    , string P_XUATXU
                                                    , string P_TENCONGVAN                                                    , string P_NGUOIKY)
        {
            string connection_string = DBOracleConnection.getConnectionString();
            OracleConnection conn = new OracleConnection(connection_string);

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                cmd.CommandText = "ht_insert_new_van_ban";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("P_TRICHYEU", OracleDbType.NVarchar2).Value = P_TRICHYEU;
                cmd.Parameters.Add("P_SOHIEU", OracleDbType.NVarchar2).Value = P_SOHIEU;
                cmd.Parameters.Add("P_NGAYDEN", OracleDbType.NVarchar2).Value = P_NGAYDEN;
                cmd.Parameters.Add("P_NGAYBANHANH", OracleDbType.NVarchar2).Value = P_NGAYBANHANH;
                cmd.Parameters.Add("P_XUATXU", OracleDbType.NVarchar2).Value = P_XUATXU;
                cmd.Parameters.Add("P_TENCONGVAN", OracleDbType.NVarchar2).Value = P_TENCONGVAN;
                cmd.Parameters.Add("P_NGUOIKY", OracleDbType.NVarchar2).Value = P_NGUOIKY;


                cmd.ExecuteNonQuery();
            }
            catch (Exception)
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

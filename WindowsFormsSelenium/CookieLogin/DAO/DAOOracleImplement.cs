using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CookieLogin.DAO
{
    class DAOOracleImplement
    {
       // return macongvan which have just been inserted
        public static int insert_new_vanban_to_dm(string P_TRICHYEU
                                                    , string P_SOHIEU
                                                    
                                                    , string P_NGAYBANHANH
                                                    , string P_XUATXU
                                                                                                        , string P_NGUOIKY
                                                    , string P_LOAI_CV
                                                    , string P_DO_KHAN)
        {
            string connection_string = DBOracleConnection.getConnectionString();
            OracleConnection conn = new OracleConnection(connection_string);

            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                cmd.CommandText = "HT_INSERT_NEW_VAN_BAN";
                   // "ht_insert_new_van_ban";
                

                cmd.Parameters.Add("P_TRICHYEU", OracleDbType.NVarchar2).Value = P_TRICHYEU;
                cmd.Parameters.Add("P_SOHIEU", OracleDbType.NVarchar2).Value = P_SOHIEU;
               
                cmd.Parameters.Add("P_NGAYBANHANH", OracleDbType.NVarchar2).Value = P_NGAYBANHANH;
                cmd.Parameters.Add("P_XUATXU", OracleDbType.NVarchar2).Value = P_XUATXU;
               
                cmd.Parameters.Add("P_NGUOIKY", OracleDbType.NVarchar2).Value = P_NGUOIKY;
                cmd.Parameters.Add("P_TENLOAI", OracleDbType.NVarchar2).Value = P_LOAI_CV;
                cmd.Parameters.Add("P_DOKHAN", OracleDbType.NVarchar2).Value = P_DO_KHAN;
                cmd.Parameters.Add("ma_cong_van", OracleDbType.Int32).Direction = ParameterDirection.Output;

              /*  OracleParameter oraParm = new OracleParameter();
                oraParm.OracleDbType = OracleDbType.Int32;
                oraParm.Direction = ParameterDirection.Output;
                oraParm.ParameterName = "ma_cong_van";
                cmd.Parameters.Add(oraParm);
                */
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                int macongvan = int.Parse(cmd.Parameters["ma_cong_van"].Value.ToString());
                return macongvan;
            }
            catch (OracleException e)
            { 
                
                
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Dispose();
                }
            }
            return -1;
        }
    }
}

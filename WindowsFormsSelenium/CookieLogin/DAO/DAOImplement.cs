using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieLogin.DAO
{
   public class DAOImplement
    {

        public static bool isExist_sokyhieu(string sokyhieu, string infoUrl)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_so_ky_hieu('{sokyhieu}','{infoUrl}')");

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static  int getTongso_vb()
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_dem_tong_so_vanban()");
            return int.Parse(dt.Rows[0][0].ToString());
        }
        public static DataTable get_vb_moi_nhat(int vb_num)
        {
          return   DBConnection.GetDataByQuery($"call vu_get_last_vb({vb_num})");
        }

        public static void insert_new_vanban(string sokyhieu, string tieude, string noigui, string ngaynhan, string pdfurl, string infourl, string docurl, string otherurl )
        {
            DBConnection.ExecuteQuery($"call vu_insert_vanban('{sokyhieu}','{tieude}','{noigui}','{ngaynhan}','{pdfurl}','{infourl}','{docurl}','{otherurl}')");
        }

        public static DataTable get_vb_vua_lay(int numrow)
        {
           return  DBConnection.GetDataByQuery($"call vu_get_last_vb_theo_id('{numrow}')");
        }
    }
}

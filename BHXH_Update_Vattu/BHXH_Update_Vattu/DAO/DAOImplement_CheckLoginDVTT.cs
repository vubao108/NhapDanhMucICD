using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BHXH_Update_Vattu.DAO
{
    public class DAOImplement_CheckLoginDVTT
    {
        public static Boolean isLoginSuccess(string _dvtt, string _matkhau)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_login_dvtt('{_dvtt}','{_matkhau}')");
            if(dt!= null)
            {
                if(dt.Rows.Count > 0)
                {
                    return true;
                }
            }
            
            return false;
        }
    }
}

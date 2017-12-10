using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace BHXH_Update_Vattu.DAO
{
    public class DAOImplement_GetAutoCompleteStringCollection
    {
        public static AutoCompleteStringCollection get_tenvattu(string dvtt, string maloaivattu, string manhomvattu,int tamngung, int dacapnhap )
        {
            AutoCompleteStringCollection acst = new AutoCompleteStringCollection();
            DataTable dt = DBConnection.GetDataByQuery($"call vu_get_tenvattu('{dvtt}','{maloaivattu}','{manhomvattu}',{tamngung},{dacapnhap})");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string info = dr[0].ToString();
                    acst.Add(info);

                }
            }
            return acst;
        }

        public static AutoCompleteStringCollection get_mahoatchat(string dvtt, string maloaivattu, string manhomvattu, int tamngung, int dacapnhap)
        {
            AutoCompleteStringCollection acst = new AutoCompleteStringCollection();
            DataTable dt = DBConnection.GetDataByQuery($"call vu_get_mahoatchat_dmdc('{dvtt}','{maloaivattu}','{manhomvattu}',{tamngung},{dacapnhap})");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string info = dr[0].ToString();
                    acst.Add(info);

                }
            }
            return acst;
        }
        public static AutoCompleteStringCollection get_maduongdung(string dvtt, string maloaivattu, string manhomvattu, int tamngung, int dacapnhap)
        {
            AutoCompleteStringCollection acst = new AutoCompleteStringCollection();
            DataTable dt = DBConnection.GetDataByQuery($"call vu_get_maduongdung_dmdc('{dvtt}','{maloaivattu}','{manhomvattu}',{tamngung},{dacapnhap})");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string info = dr[0].ToString();
                    acst.Add(info);

                }
            }
            return acst;
        }

        public static AutoCompleteStringCollection get_sodk(string dvtt, string maloaivattu, string manhomvattu, int tamngung, int dacapnhap)
        {
            AutoCompleteStringCollection acst = new AutoCompleteStringCollection();
            DataTable dt = DBConnection.GetDataByQuery($"call vu_get_sodangky_dmdc('{dvtt}','{maloaivattu}','{manhomvattu}',{tamngung},{dacapnhap})");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string info = dr[0].ToString();
                    acst.Add(info);

                }
            }
            return acst;
        }

        public static AutoCompleteStringCollection get_dongia(string dvtt, string maloaivattu, string manhomvattu, int tamngung, int dacapnhap)
        {
            AutoCompleteStringCollection acst = new AutoCompleteStringCollection();
            DataTable dt = DBConnection.GetDataByQuery($"call vu_get_dongia_bv('{dvtt}','{maloaivattu}','{manhomvattu}',{tamngung},{dacapnhap})");
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    string info = dr[0].ToString().Replace(",", "");
                    //string d_info = double.Parse(info).ToString("G29");
                    if (info.Contains("."))
                    {
                        info = info.TrimEnd('0');
                        info = info.TrimEnd('.');
                    }
                   
                    acst.Add(info);

                }
            }
            return acst;
        }
    }
}
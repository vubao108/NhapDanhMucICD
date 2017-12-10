using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BHXH_Update_Vattu.DAO
{
    class DAOImplement_GetDataSource
    {
        public static DataTable getVatTu_BV(string dvtt,string tenvattu, string mahoatchat, string maduongdung, 
                                            string sodk, double dongia, int tamngung, int dacapnhap, string maloaivattu, string manhomvattu )
        {
            return DBConnection.GetDataByQuery($"call vu_dc_tb_vattu_tim('{dvtt}','{tenvattu}','{mahoatchat}','{maduongdung}','{sodk}',{dongia},{tamngung},{dacapnhap},'{maloaivattu}','{manhomvattu}')");
        }
        public static DataTable getVatTu_BHXH(string tenvattu, string mahoatchat, string maduongdung,
                                          string sodk, double dongia)
        {
            /*
            string pattern = @"\.(\d+)(0+)$";
            mahoatchat = Regex.Replace(mahoatchat, pattern, @".$1");

            maduongdung = Regex.Replace(maduongdung, pattern, @".$1");
            */

            return DBConnection.GetDataByQuery($"call vu_bhxh_tim_vat_tu('{tenvattu}','{mahoatchat}','{maduongdung}','{sodk}',{dongia})");
        }

        public static DataTable getLoaiVatTu(string dvtt)
        {
            return DBConnection.GetDataByQuery($"call vu_get_list_tenloaivattu('{dvtt}')");

        }
        public static DataTable getNhomVatTu(string dvtt, string maloaivattu)
        {
            return DBConnection.GetDataByQuery($"call vu_get_list_tennhomvattu('{dvtt}','{maloaivattu}')");
        }

        public static DataTable getVatTu_BV_BHXH(string dvtt, string search_tenvattu, string search_mahoatchat, string search_maduongdung, string search_sodangky, double search_dongia)
        {
            throw new NotImplementedException();
        }
    }
}

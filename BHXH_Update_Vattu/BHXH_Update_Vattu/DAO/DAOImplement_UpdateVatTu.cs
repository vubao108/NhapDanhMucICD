using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BHXH_Update_Vattu.DAO
{
    class DAOImplement_UpdateVatTu
    {
        public static void update_thongtin_thau(string dvtt, string tenvattu, string mahoatchat, string maduongdung, string sodk, double dongia, string quyetdinh, string goithau, string nhomthau, string socvbhxh)
        {
            DBConnection.ExecuteQuery($"call vu_dc_tb_vattu_update('{dvtt}','{tenvattu}','{mahoatchat}','{maduongdung}','{sodk}',{dongia},'{quyetdinh}','{goithau}','{nhomthau}', '{socvbhxh}')");
        }
        public static void auto_update_thongtin_thau_one_one(string dvtt)
        {
            //int _is_tenvattu = 1, _is_maduongdung = 1, _is_mahoatchat=1, _is_sodk =1, _is_dongia = 1;
            //DBConnection.ExecuteQuery($"call vu_update_list_vattu_bv_like_bhxh('{dvtt}',{_is_tenvattu},{_is_mahoatchat},{_is_maduongdung},{_is_sodk},{_is_dongia})");
            DBConnection.ExecuteQuery($"call vu_update_list_vattu_bv_like_bhxh_v2('{dvtt}')");
        }
    }
}

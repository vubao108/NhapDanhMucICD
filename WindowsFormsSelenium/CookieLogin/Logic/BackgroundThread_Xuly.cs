using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieLogin.DAO;
using CookieLogin.Logic;
using System.Threading;
using System.Data;

namespace CookieLogin
{
    public class BackgroundThread_Xuly
    {
        public delegate void Del_UpdateUI(int sovanban_dalay);
        //public Del_UpdateUI updateUI;
        public static void xuly( Del_UpdateUI del_UpdateUI = null)
        {

            var loginAddress = "http://guinhanvb.hatinh.gov.vn/names.nsf?Login";
            string getAddress = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=1";
            string baseAddress = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=";
            int get_count = 0;
            var loginData = new NameValueCollection
            {
              { "Username", "benhvienhuongson.hs" },
              { "Password", "huongson123" }
            };

            

            while (true)
            {
                var client = new CookieRequest();
                client.Login(loginAddress, loginData);
                string strdata = client.getHtmlPageStr(getAddress);


                ParseHtml parser = new ParseHtml(strdata);
                int totalItem = int.Parse(parser.get_total_item());
                int lastPage = totalItem / 20 + 1;
                int tongso_in_db = DAOImplement.getTongso_vb();


                for (int page = 1; page <= lastPage && tongso_in_db < totalItem ; page++)
                {

                    parser = new ParseHtml(client.getHtmlPageStr(baseAddress + page));
                    var list_node = parser.get_list_tr();
                    for (int i = 2; i < list_node.Count && tongso_in_db < totalItem; i++)
                    {
                        HtmlNode current_node = list_node[i];
                        string sokyhieu = parser.get_sokyhieu(current_node);
                        string infoUrl = parser.get_infourl(current_node);
                        if (!DAOImplement.isExist_sokyhieu(sokyhieu, infoUrl))
                        {
                            string tieude = parser.get_tieude(current_node);
                            string noigui = parser.get_noigui(current_node);
                            string ngaynhan = parser.get_ngaynhan(current_node);
                            string infourl = parser.get_infourl(current_node);


                            string detail_html_page = client.getHtmlPageStr(infourl);
                            ParseHtml detailParser = new ParseHtml(detail_html_page);
                            Dictionary<String, String> linkDict = detailParser.get_FileUrl();
                            string pdfurl = linkDict["pdfLink"];
                            string docurl = linkDict["docLink"];
                            string otherurl = linkDict["otherLink"];
                            string ngay_ban_hanh = detailParser.get_ngay_ban_hanh();
                            string nguoi_ky = detailParser.get_nguoi_ky();
                            string chuc_vu = detailParser.get_chuc_vu();
                            string do_khan = detailParser.get_do_khan();
                            string loai_van_ban = detailParser.get_loai_van_ban();



                            DAOImplement.insert_new_vanban(sokyhieu, tieude, noigui, ngaynhan, pdfurl, infourl, docurl, otherurl, ngay_ban_hanh, nguoi_ky, chuc_vu, do_khan, loai_van_ban);
                            tongso_in_db++;

                            ++get_count;
                            del_UpdateUI?.Invoke(get_count);
                        }
                        else
                        {
                           
                        }

                    }
                }
                update_to_oracle();
                del_UpdateUI?.Invoke(-1);
                Thread.Sleep(5*60*1000);
            }
            
        }

        private static void update_to_oracle()
        {
            DataTable dt = DAOImplement.get_vb_chua_insert_to_oracle();
            if (dt != null)
            {
                foreach (DataRow r in dt.Rows)
                {
                    int id = int.Parse(r["id"].ToString());
                    string trich_yeu = r["tieu_de"].ToString();
                    string so_hieu = r["so_ky_hieu"].ToString();
                    string tmp_ngay_ban_hanh = r["ngay_ban_hanh"].ToString();
                    string ngay_ban_hanh = tmp_ngay_ban_hanh.Substring(0, 10);
                    if (ngay_ban_hanh == "01/01/0001")
                    {
                        ngay_ban_hanh = "";
                    }

                    string xuat_xu = r["noi_gui"].ToString();
                    string nguoi_ky = r["nguoi_ky"].ToString();
                    string loai_cv = r["loai_van_ban"].ToString();
                    string do_khan = r["do_khan"].ToString();

                    int ma_van_ban = DAOOracleImplement.insert_new_vanban_to_dm(trich_yeu, so_hieu,
                                                                        ngay_ban_hanh, xuat_xu,
                                                                        nguoi_ky, loai_cv, do_khan);
                    if (ma_van_ban > 0)
                    {
                        DAOImplement.update_ma_van_ban(id, ma_van_ban);
                    }
                }
                
            }
        }
    }
    

}


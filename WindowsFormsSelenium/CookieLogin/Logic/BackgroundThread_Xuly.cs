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

namespace CookieLogin
{
    public class BackgroundThread_Xuly
    {
        public delegate void Del_UpdateUI(int sovanban_dalay);
        //public Del_UpdateUI updateUI;
        public static int xuly(int break_max, Del_UpdateUI del_UpdateUI = null)
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
                string totalItem = parser.get_total_item();
                int lastPage = int.Parse(totalItem) / 20 + 1;

                int break_flag = 0;
                if (break_max == 0)
                {
                    break_max = 20;
                }

                for (int page = 1; page <= lastPage && break_flag < break_max; page++)
                {

                    parser = new ParseHtml(client.getHtmlPageStr(baseAddress + page));
                    var list_node = parser.get_list_tr();
                    for (int i = 2; i < list_node.Count && break_flag < break_max; i++)
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
                            break_flag = 0;

                            ++get_count;
                            del_UpdateUI?.Invoke(get_count);
                        }
                        else
                        {
                            ++break_flag;
                        }

                    }
                }
                del_UpdateUI?.Invoke(-1);
                Thread.Sleep(5*60*1000);
            }
            return get_count;
        }

    }

    }


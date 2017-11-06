using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Data;

namespace CookieLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            var loginAddress = "http://guinhanvb.hatinh.gov.vn/names.nsf?Login";
            string getAddress = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=1";
            string baseAddress = "http://guinhanvb.hatinh.gov.vn/guinhan/index.nsf/frmShowData?openform&dbtype=vbden&hienthi=toanbo&noinhan=benhvienhuongson.hs&startpage=";
            var loginData = new NameValueCollection
            {
              { "Username", "benhvienhuongson.hs" },
              { "Password", "huongson123" }
            };

            var client = new CookieRequest();
            client.Login(loginAddress, loginData);


            string strdata = client.getHtmlPageStr(getAddress);
           

            ParseHtml parser = new ParseHtml(strdata);
            string totalItem = parser.get_total_item();
            int lastPage = int.Parse(totalItem) / 20 + 1;

            int break_flag = 0;
            int break_max = 20;
            for (int page = 1; page <= lastPage && break_flag < break_max ; page++)
            {
                Console.WriteLine("page              : " + page);
                parser = new ParseHtml(client.getHtmlPageStr(baseAddress + page));
                var list_node = parser.get_list_tr();
                for (int i = 2; i < list_node.Count && break_flag < break_max; i++)
                {
                    HtmlNode current_node = list_node[i];
                    string sokyhieu = parser.get_sokyhieu(current_node);
                    if (!isExist_sokyhieu(sokyhieu))
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

                        Console.WriteLine((i - 1) + "\t" + sokyhieu + "\t" + tieude + "\t" + noigui + "\t" + ngaynhan );
                        Console.WriteLine(pdfurl);

                        DBConnection.ExecuteQuery($"call vu_insert_vanban('{sokyhieu}','{tieude}','{noigui}','{ngaynhan}','{pdfurl}','{docurl}')");
                        break_flag = 0;
                    }
                    else
                    {
                        ++break_flag;
                    }

                }
            }
            Console.WriteLine("Da xu ly xong");
            Console.ReadKey();

        }
        static bool isExist_sokyhieu(string sokyhieu)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_so_ky_hieu('{sokyhieu}')");

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}

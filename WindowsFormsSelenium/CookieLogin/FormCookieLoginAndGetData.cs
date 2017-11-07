using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieLogin
{
    public partial class FormCookieLoginAndGetData : Form
    {
        public FormCookieLoginAndGetData()
        {
            InitializeComponent();
        }

        private void FormCookieLoginAndGetData_Load(object sender, EventArgs e)
        {
            updateTable();
        }

        private void bg_xuly()
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
            int break_max = int.Parse(tbBreak.Text);
            for (int page = 1; page <= lastPage && break_flag < break_max; page++)
            {
              
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


                        DBConnection.ExecuteQuery($"call vu_insert_vanban('{sokyhieu}','{tieude}','{noigui}','{ngaynhan}','{pdfurl}','{docurl}')");
                        break_flag = 0;

                     
                    }
                    else
                    {
                        ++break_flag;
                    }

                }
            }
        }
        private void updateTable()
        {
            int vb_num = int.Parse(tbNum.Text);
            dgv.DataSource = DBConnection.GetDataByQuery($"call vu_get_last_vb({vb_num})");
        }

        private bool isExist_sokyhieu(string sokyhieu)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_so_ky_hieu('{sokyhieu}')");

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            btGetData.Enabled = false;
            Thread t = new Thread(bg_xuly);
            t.Start();
            lbState.Text = "Đang xử lý";
            while (true)
            {
                if (!t.IsAlive)
                {
                    lbState.Text = "Đã xử lý xong";
                    updateTable();
                    break;
                }
                else
                {
                    
                    
                    updateTable();
                    Thread.Sleep(3000);
                }
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

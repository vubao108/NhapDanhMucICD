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
        int sovanbanmoi = 0;
        public FormCookieLoginAndGetData()
        {
            InitializeComponent();
        }

        private void FormCookieLoginAndGetData_Load(object sender, EventArgs e)
        {
            tbNum.KeyDown += new KeyEventHandler(tbNum_KeyDown);
            updateTable();
            lbState.Text = "";
        }

        private void tbNum_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                int num_row = 10;
                if (int.TryParse(tbNum.Text, out num_row) && num_row > 0)
                {
                    updateTable();
                }
                else
                {
                    tbNum.Text = "10";
                }
            }
            
        }
        private void update_sovb_dalay(int sovb)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => update_sovb_dalay(sovb)));
            }
            else
            {
                lbState.Text = String.Format("Đang xử lý: Đã lấy dc: {0} văn bản mới ", sovb);
                updateTable();
            }
        }

        private int bg_xuly()
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
                    string infoUrl = parser.get_infourl(current_node);
                    if (!isExist_sokyhieu(sokyhieu, infoUrl))
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


                        DBConnection.ExecuteQuery($"call vu_insert_vanban('{sokyhieu}','{tieude}','{noigui}','{ngaynhan}','{pdfurl}','{infourl}','{docurl}','{otherurl}')");
                        break_flag = 0;

                        ++get_count;
                        update_sovb_dalay(get_count);
                    }
                    else
                    {
                        ++break_flag;
                    }

                }
            }
            return get_count;
        }
        private void updateTable()
        {
            int vb_num = int.Parse(tbNum.Text);
            dgv.DataSource = DBConnection.GetDataByQuery($"call vu_get_last_vb({vb_num})");
            format_Datagridview();
            lbTongso.Text = "Tổng số: " + getTongso_vb() + " văn bản";
            
        }
        private int getTongso_vb()
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_dem_tong_so_vanban()");
            return int.Parse(dt.Rows[0][0].ToString());
        }

        private bool isExist_sokyhieu(string sokyhieu, string infoUrl)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call vu_check_so_ky_hieu('{sokyhieu}','{infoUrl}')");

            if (dt.Rows.Count == 0)
            {
                return false;
            }
            return true;
        }

        private async void btGetData_Click(object sender, EventArgs e)
        {
            btGetData.Enabled = false;
            tbBreak.Enabled = false;
            Task<int> getDataTask = Task.Run(() => bg_xuly());
            lbState.Text = "Đang xử lý";
            lbState.Enabled = false;

            await getDataTask;
            updateTable();
            sovanbanmoi = getDataTask.Result;
            lbState.Text = String.Format("Đã xử lý xong. Lấy được : {0} văn bản mới",sovanbanmoi) ;
            btGetData.Enabled = true;
            lbState.Enabled = true;
            tbBreak.Enabled = true;
               
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbCellContent.Text = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            catch(System.ArgumentOutOfRangeException)
            {

            }
        }

        private void lbState_Click(object sender, EventArgs e)
        {
            Popup_Vanbanmoi pvb = new Popup_Vanbanmoi();
            pvb.NumRow = sovanbanmoi;
            pvb.ShowDialog();
        }
        private void format_Datagridview()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}",row.Index + 1);
            }
            dgv.RowHeadersWidth = 70;

            dgv.Columns["id"].Width = 50;
            //dgv.Columns["tieu_de"].Width = 200;
            dgv.Columns["Tiêu đề"].Width = 200;
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            updateTable();
        }

        
    }
}

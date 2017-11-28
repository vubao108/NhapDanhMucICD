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
using CookieLogin.DAO;

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
            {   if (sovb >= 0)
                {

                    lbState.Text = String.Format("Đang xử lý: Đã lấy dc: {0} văn bản mới ", sovb);
                    updateTable();
                }
                else
                {
                    lbState.Text = lbState.Text + "\n" +  $"{DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss zzz")} Đang đợi 5 phút trước khi check có văn bản mới ";
                }
            }
        }
   
        private void updateTable()
        {
            int vb_num = int.Parse(tbNum.Text);
            dgv.DataSource = DAOImplement.get_vb_moi_nhat(vb_num);
            format_Datagridview();
            lbTongso.Text = "Tổng số: " + DAOImplement.getTongso_vb() + " văn bản";
            
        }
       


        private async void btGetData_Click(object sender, EventArgs e)
        {
            btGetData.Enabled = false;
            tbBreak.Enabled = false;
            int break_max;
            int.TryParse(tbBreak.Text, out break_max);

            Task getDataTask = Task.Run(() => BackgroundThread_Xuly.xuly(update_sovb_dalay));
            //lbState.Text = "Đang xử lý";
            //lbState.Enabled = false;

            await getDataTask;
            updateTable();
            // sovanbanmoi = getDataTask.Result;
            //lbState.Text = String.Format("Đã xử lý xong. Lấy được : {0} văn bản mới",sovanbanmoi) ;
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

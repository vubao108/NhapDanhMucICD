using NhapDanhMucIICD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhapDanhMucIICD.View
{
    public partial class FormCauhinhLoi : Form
    {
        private String madonvi;
        public String Madonvi
        {
            get
            {
                return madonvi;
            }
            set
            {
                madonvi = value;
            }
        }

        public FormCauhinhLoi()
        {
            InitializeComponent();
        }

        private void FormCauhinhLoi_Load(object sender, EventArgs e)
        {
            DataTable dt = DBConnection.GetDataByQuery($"call hth_vu_lay_danh_muc_quy_tac('{madonvi}')");
            dgvQuytac.DataSource = dt;

            tbTen.DataBindings.Add("Text", dgvQuytac.DataSource, "ten_quy_tac");
            tbMota.DataBindings.Add("Text", dgvQuytac.DataSource, "mo_ta");
            tbID.DataBindings.Add("Text", dgvQuytac.DataSource, "id");
            tbTen.Enabled = false;
            tbMota.Enabled = false;
            tbID.Enabled = false;
            btLuu.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  tbTen.Clear();
         //   tbTen.DataBindings.Clear();
            tbTen.Enabled = true;
            tbTen.Text = "";
           // tbMota.Clear();
           // tbMota.DataBindings.Clear();
            tbMota.Enabled = true;
            tbMota.Text = "";
            //tbID.Clear();
            tbID.Text = "";
            

            btXoa.Enabled = false;
            btSua.Enabled = false;
            btLuu.Enabled = true;
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            Quytac q = new Quytac
            {
                Ten = tbTen.Text,
                Mota = tbMota.Text,
                Dvtt = this.madonvi

            };

            if (q.Ten.Length > 0)
            {
                DBConnection.ExecuteQuery($"call hth_vu_them_quy_tac('{q.Ten}','{q.Mota}','{q.Dvtt}')");
                dgvQuytac.DataSource = DBConnection.GetDataByQuery($"call hth_vu_lay_danh_muc_quy_tac('{this.Madonvi}')");
                tbTen.DataBindings.Clear(); 
                tbTen.DataBindings.Add("Text", dgvQuytac.DataSource, "ten_quy_tac");
                tbTen.Enabled = false;
                tbMota.DataBindings.Clear();
                tbMota.DataBindings.Add("Text", dgvQuytac.DataSource, "mo_ta");
                tbMota.Enabled = false;

                btLuu.Enabled = false;
               
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {

        }
    }
}


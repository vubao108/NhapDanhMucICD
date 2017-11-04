using NhapDanhMucIICD.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhapDanhMucIICD
{
    public partial class MainForm : Form
    {
        private string madonvi;
        public string Madonvi
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

        private int DangNhapHandle(string id, string matkhau)
        {
            this.madonvi = id;
            btICD.Enabled = true;
            btLoi.Enabled = true;
            return 0;
        }
        public MainForm()
        {
            InitializeComponent();
           

        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btICD_Click(object sender, EventArgs e)
        {
            Form1 icdForm = new Form1();
            icdForm.Madonvi = this.madonvi;
            icdForm.ShowDialog();

        }

        private void btLoi_Click(object sender, EventArgs e)
        {
            FormCauhinhLoi errorForm = new FormCauhinhLoi();
            errorForm.Madonvi = this.Madonvi;
            errorForm.ShowDialog();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            formDangNhap.DangNhapHandler += DangNhapHandle;

        }
    }
}

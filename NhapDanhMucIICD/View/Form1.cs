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
    public partial class Form1 : Form
    {
        private string madonvi = "42007";
        public String Madonvi
        {
            set
            {
                madonvi = value;
            }
        }
        private PopupForm pform;
        //TextboxControl tbControl;
        public Form1()
        {
            InitializeComponent();
            loadUserControl();
        }

        private void loadUserControl()
        {
           // pform = new PopupForm();
            

            ThemControl tc = new ThemControl();
            tc.delThemHandler += ThemHandler;
            //tableLayoutPanel2.Controls.Add(tc,1,1);
            //tableLayoutPanel2.SetColumnSpan(tc, 2);
            // splitContainer1.Panel2.Controls.Add(tc);
            tabPage2.Controls.Add(tc);

            tc.Dock = DockStyle.Fill;

            // tbControl = new TextboxControl();

            // tbControl.delDisplayPopup = this.displayPopup;
            //tableLayoutPanel1.Controls.Add(tbControl, 0, 0);
            //splitContainer2.Panel1.Controls.Add(tbControl);
            //tbControl.Dock = DockStyle.Fill;

            this.tbICD.KeyDown += TbICD_KeyDown;
        }
        private int ThemHandler(BindingList<Canlamsang> blist)
        {
            if(lb_icd_dachon.Text.Length > 3)
            {
                string ma_icd = lb_icd_dachon.Text.Substring(0, 3);
                foreach(Canlamsang c in blist)
                {
                    DBConnection.ExecuteQuery($"call hth_vu_insert_icd_xetnghiem('{int.Parse(c.Maso)}', '{ma_icd}', '{madonvi}') ");
                }
                return 0;
                
            }
            else
            {
                return 1;
            }
        }
        private void displayPopup()
        {
             pform = new PopupForm();
             pform.hanleChon = handleChon;
             DataTable dt = DBConnection.GetDataByQuery($"call hth_vu_tim_icd('{tbICD.Text}')");
             pform.Table.loadCheckBoxColumn("check");
             pform.Table.setDataSource(dt);
             pform.Table.Table.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
             pform.Table.Table.MultiSelect = false;
             pform.Table.SingleCheck = true;
             pform.ShowDialog();
         


            
        }
        private void handleChon(List<object> list)
        {
            foreach(object o in list)
            {
                if (o is Canlamsang)
                {
                    Canlamsang c = o as Canlamsang;
                    lb_icd_dachon.Text = c.Maso + " - " + c.Ten;
                }
            }
        }


        private void TbICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                displayPopup();
            }
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbICD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

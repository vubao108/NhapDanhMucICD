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
        private PopupForm pform;
        TextboxControl tbControl;
        public Form1()
        {
            InitializeComponent();
            loadUserControl();
        }

        private void loadUserControl()
        {
            pform = new PopupForm();
            

            ThemControl tc = new ThemControl();
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

            
        }
        private void displayPopup()
        {
            pform.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

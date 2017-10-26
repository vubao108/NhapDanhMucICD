using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestFormLoginControl
{
    public partial class TestLoginControl : Form
    {
        public TestLoginControl()
        {
            InitializeComponent();
        }
        private void loginSuccessHandler(object sender, EventArgs e)
        {
            MessageBox.Show("login success... ", "login validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void loginFailedHandler(object sender, EventArgs e)
        {
            MessageBox.Show("login failed... ", "login validation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    


    }
}

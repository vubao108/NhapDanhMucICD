using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubmitButton
{
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }
        public delegate void EventHandler(Object sender, EventArgs e);
        public event EventHandler LoginSuccess;
        public event EventHandler LoginFailed;

        private bool LoginCheck(string pName, string pPassword)
        {
            return pPassword.Equals("secret");
        }
        private void loginButtonClicked(object sender, EventArgs e)
        {
            if(tbName.Text.Length == 0)
            {
                errorProvider1.SetError(tbName, "please enter a user name");
            //    statusStrip1.Text = "Please enter a user name";
                return;
            }
            else
            {
                errorProvider1.SetError(tbName, "");
             //   statusStrip1.Text = "";
            }
            if(tbPass.Text.Length == 0)
            {
                errorProvider1.SetError(tbPass, "please enter a password");
            //    statusStrip1.Text = "please enter a password";
                return;
            }
            else
            {
                errorProvider1.SetError(tbPass, "");
            //    statusStrip1.Text = "";
            }
            if(LoginCheck(tbName.Text, tbPass.Text))
            {
                if(LoginSuccess != null)
                {
                    LoginSuccess(this, new EventArgs());
                }
            }
            else
            {
                if(LoginFailed != null)
                {
                    LoginFailed(this, new System.EventArgs());
                }
            }
        }

        public string LabelName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        public string LoginButtonText
        {
            get
            {
                return btLogin.Text;
            }
            set
            {
                btLogin.Text = value;
            }
        }
        public string UserName
        {
            set
            {
                tbName.Text = value;
            }
        }
        public string Password
        {
            set
            {
                tbPass.Text = value;
            }
        }
    }
}

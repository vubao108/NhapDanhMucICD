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
    public partial class SubmitButton : UserControl
    {
        public delegate void SubmitClickedHandler();
        public event SubmitClickedHandler SubmitClicked;
        protected virtual void OnSubmitClicked()
        {
            if (SubmitClicked != null)
            {
                SubmitClicked();
            }
        }

        public SubmitButton()
        {
            InitializeComponent();
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            if(tbName.Text.Length == 0)
            {
                MessageBox.Show("please enter your name");
            }else{
                OnSubmitClicked();
            }

        }
        public string UserName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
    }   
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhapDanhMucIICD
{
    public partial class TextboxControl : UserControl
    {
        public override String Text => textBox1.Text;

        public DelegateDisplayPopup delDisplayPopup;
        public TextboxControl()
        {
            InitializeComponent();
        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (delDisplayPopup != null)
                {
                    delDisplayPopup();
                }
            }
        }
    }

    
}

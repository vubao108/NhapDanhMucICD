using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    class FileTextBox :TextBox
    {
        protected override void OnTextChanged(EventArgs e)
        {
            // base.OnTextChanged(e);
            if (!File.Exists(this.Text))
            {
                this.ForeColor = Color.Red;
            }
            else
            {
                this.ForeColor = Color.Black;
            }
            base.OnTextChanged(e);
        }
    }
}

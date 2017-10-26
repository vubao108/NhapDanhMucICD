using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDemo
{
    public partial class Form1 : Form
    {
        FileTextBox f1;
        public Form1()
        {
            InitializeComponent();
            loadControl();
        }

        private void loadControl()
        {
            f1 = new FileTextBox();
            this.Controls.Add(f1);
        }
    }
}

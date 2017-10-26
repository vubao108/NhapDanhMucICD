using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestEditMask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LaterInitializeComponent()
        {
            this.editMask1.Mask = "[###]-(##)-#####";
            this.editMask1.Name = "editMask";
            this.editMask1.TabIndex = 0;
        }
    }
}

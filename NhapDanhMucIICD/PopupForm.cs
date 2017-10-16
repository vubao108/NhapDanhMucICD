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
    public partial class PopupForm : Form
    {
        private PopupTable table;
        public PopupForm()
        {
            Table = new PopupTable();
            InitializeComponent();
        }

        public PopupTable Table { get => table; set => table = value; }

        private void PopupForm_Load(object sender, EventArgs e)
        {
            

            //this.Controls.Add(Table);
            //table.Dock = DockStyle.Fill;
        }
        
    }
}

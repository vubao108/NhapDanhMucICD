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
    public partial class PopupTable : UserControl
    {
        public PopupTable()
        {
            InitializeComponent();
        }

        public void setDataSource(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
        }
    }
}

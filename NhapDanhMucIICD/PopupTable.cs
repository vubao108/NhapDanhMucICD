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
        public DataGridView Table => dataGridView1;
        public PopupTable()
        {
            InitializeComponent();
        }

        public void setDataSource(DataTable dt)
        {
            this.dataGridView1.DataSource = dt;
        }
        public void loadCheckBoxColumn(string namestr)
        {
            DataGridViewCheckBoxColumn cc = new DataGridViewCheckBoxColumn();
            cc.ValueType = typeof(bool);
            cc.Name = namestr;
            cc.HeaderText = " ";
            cc.Width = 30;
            dataGridView1.Columns.Add(cc);
        }
    }
}

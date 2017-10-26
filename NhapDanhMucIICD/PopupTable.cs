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
        private bool singleCheck = false;
        public bool SingleCheck
        {
            set
            {
                singleCheck = value;
            }
        }
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
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (singleCheck == true)
            {
                if (dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[0].Value = null;
                    }

                    //check select row
                    dataGridView1.CurrentRow.Cells[0].Value = true;
                }
            }
        }
    }
}

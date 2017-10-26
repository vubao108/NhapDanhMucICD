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
        public DelegateChon hanleChon;

        private PopupTable table;
        public PopupForm()
        {
            Table = new PopupTable();
            InitializeComponent();
            loadPopup();
        }

        public PopupTable Table { get => table; set => table = value; }

        private void PopupForm_Load(object sender, EventArgs e)
        {
           
            

           
            //table.Dock = DockStyle.Fill;

        }
        private void loadPopup()
        {
            splitContainer1.Panel1.Controls.Add(Table);
            Table.Dock = DockStyle.Fill;
        }

        private void btChon_Click(object sender, EventArgs e)
        {
            List<object> list = new List<object>();
            foreach (DataGridViewRow r in table.Table.Rows)
            {
                DataGridViewCheckBoxCell cb = (DataGridViewCheckBoxCell)r.Cells["check"];
                if(cb.Value != null && (bool)cb.Value)
                {
                    string ma = r.Cells[1].Value.ToString();
                    string ten = r.Cells[2].Value.ToString();
                    Canlamsang c = new Canlamsang
                    {
                        Maso = ma,
                        Ten = ten

                    };
                    list.Add(c);
                }
            }

            hanleChon(list);
            this.Close();

        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

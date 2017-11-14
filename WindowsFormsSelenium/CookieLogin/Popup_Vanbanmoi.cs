using CookieLogin.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CookieLogin
{
    public partial class Popup_Vanbanmoi : Form
    {
        public int NumRow
        {
            get;set;
            


        }
        public Popup_Vanbanmoi()
        {
            InitializeComponent();
        }

        private void Popup_Vanbanmoi_Load(object sender, EventArgs e)
        {
            if (this.NumRow > 0) {
                dataGridView1.DataSource = DAOImplement.get_vb_vua_lay(this.NumRow);
                format_Datagridview();
            }
        }
        private void format_Datagridview()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = String.Format("{0}", row.Index + 1);
            }
        }
    }
}

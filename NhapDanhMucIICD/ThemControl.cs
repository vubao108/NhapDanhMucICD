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
    public partial class ThemControl : UserControl
    {
        private PopupForm pform;
        private TextboxControl tbc01;
        public ThemControl()
        {
            InitializeComponent();
            loadUserControl();
        }

        private void loadUserControl()
        {
            
             tbc01 = new TextboxControl();
            tbc01.delDisplayPopup = displayPopup;
            tableLayoutPanel1.Controls.Add(tbc01, 0, 0);
            tbc01.Dock = DockStyle.Fill;

            DataTable dt1 = DBConnection.GetDataByQuery($"call hth_vu_lay_danh_sach_icd_xet_nghiem('42007')");
            this.DataGridView1.DataSource = dt1;
            this.DataGridView1.Columns["tên xét nghiệm"].Width = 300;
        }
        private void displayPopup()
        {
            pform = new PopupForm();
            DataTable dt = DBConnection.GetDataByQuery($"call hth_vu_tim_xet_nghiem('{tbc01.Text}','42007')");
            pform.Table.loadCheckBoxColumn("check");
            pform.Table.setDataSource(dt);
            pform.Table.Table.Columns["TEN_XETNGHIEM"].Width = 300;
            pform.ShowDialog();
        }


    }
}

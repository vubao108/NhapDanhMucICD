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
        public delegate int DelThem(BindingList<Canlamsang> list);
        public DelThem delThemHandler;

        private PopupForm pform;
        private TextboxControl tbc01;
        private BindingList<Canlamsang> blist;
        public ThemControl()
        {
            InitializeComponent();
            loadUserControl();
            blist = new BindingList<Canlamsang>();
            DgvXNdachon.DataSource = blist;
            DgvXNdachon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void loadUserControl()
        {
            
             tbc01 = new TextboxControl();
            tbc01.delDisplayPopup = displayPopup;
            tableLayoutPanel1.Controls.Add(tbc01, 1, 0);
            tbc01.Dock = DockStyle.Fill;

            DataTable dt1 = DBConnection.GetDataByQuery($"call hth_vu_lay_danh_sach_icd_xet_nghiem('42007')");
            this.DgvDanhmuctong.DataSource = dt1;
            this.DgvDanhmuctong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void displayPopup()
        {
            pform = new PopupForm();
            pform.hanleChon = handleChon;
            DataTable dt = DBConnection.GetDataByQuery($"call hth_vu_tim_xet_nghiem('{tbc01.Text}','42007')");
            pform.Table.loadCheckBoxColumn("check");
            pform.Table.setDataSource(dt);
            pform.Table.Table.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            pform.ShowDialog();
        }
        private void handleChon(List<object> list)
        {
            foreach(object o in list)
            {
                if(o is Canlamsang)
                {
                    blist.Add(o as Canlamsang);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            int result = delThemHandler(blist);
            if (result == 0)
            {
                lbThemResult.Text = "da them thanh cong";
                blist.Clear();

                DataTable dt1 = DBConnection.GetDataByQuery($"call hth_vu_lay_danh_sach_icd_xet_nghiem('42007')");
                this.DgvDanhmuctong.DataSource = dt1;
            }
            else
            {
                lbThemResult.Text = "chọn bệnh đã";
            }

        }
    }
}

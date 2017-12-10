using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHXH_Update_Vattu.Logic;
using BHXH_Update_Vattu.DAO;

namespace BHXH_Update_Vattu
{
    public partial class formUpdate : Form

    {
        public delegate void DelUpdateMainForm();
        public DelUpdateMainForm updateMainForm;
        public VatTu Current_VatTu { get; set; }

        public formUpdate(VatTu vattu)
        {
            this.Current_VatTu = vattu;
            InitializeComponent();
            cbTenvattu.Checked = true;
            lbTenvattu.Text = Current_VatTu.TenVatTu;
            cbMahoatchat.Checked = true;
            lbMahoatchat.Text = Current_VatTu.MaHoatChat;
            cbMaduongdung.Checked = true;
            lbMaduongdung.Text = Current_VatTu.MaDuongDung;
            cbSodangky.Checked = true;
            lbSodangky.Text = Current_VatTu.SoDK;
            cbDongia.Checked = true;
            lbDongia.Text = Current_VatTu.DonGia.ToString();

            lbGoithau.Text = Current_VatTu.GoiThau;
            lbNhomthau.Text = Current_VatTu.NhomThau;
            lbSoquyetdinh.Text = "ban đầu: " + Current_VatTu.SoQuyetDinh + "   | cập nhập mới: " + Current_VatTu.SoQuyetDinh_CapNhap;
            lbSoCVBHXH.Text = Current_VatTu.SoCVBHXH;
            if( Current_VatTu.DaCapNhap == 1)
            {
                lbTrangthai.Text = "Đã cập nhập";
            }
            else
            {
                lbTrangthai.Text = "Chưa cập nhập";
            }

            loadDataGridView();
            //dataGridView1.ClearSelection();
          //  DataGridViewRow selectedRow = dataGridView1.CurrentRow;
          /*
            if (selectedRow != null)
            {
                lbState.Text = "";
                tbGoiThau.Text = selectedRow.Cells[6].Value.ToString();
                tbNhomThau.Text = selectedRow.Cells[7].Value.ToString();
                tbSoQuyetDinh.Text = selectedRow.Cells[5].Value.ToString();
            }
            */

        }
        private void loadDataGridView()
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            string search_tenvattu = "";
            string search_mahoatchat = "";
            string search_maduongdung = "";
            string search_sodangky = "";
            double search_dongia = -1;

            {
                if (cbTenvattu.CheckState == CheckState.Checked)
                    search_tenvattu = Current_VatTu.TenVatTu;

                if (cbMahoatchat.CheckState == CheckState.Checked)
                    search_mahoatchat = Current_VatTu.MaHoatChat;

                if (cbMaduongdung.CheckState == CheckState.Checked)
                    search_maduongdung = Current_VatTu.MaDuongDung;

                if (cbSodangky.CheckState == CheckState.Checked)
                    search_sodangky = Current_VatTu.SoDK;

                if (cbDongia.CheckState == CheckState.Checked)
                    search_dongia = Current_VatTu.DonGia;


            }
            this.dataGridView1.DataSource = DAOImplement_GetDataSource.getVatTu_BHXH(search_tenvattu, search_mahoatchat, search_maduongdung, search_sodangky, search_dongia);
            format_Dongia_Column();
            try { 
                DataGridViewRow selectedRow = dataGridView1.Rows[0];

           
                lbState.Text = "";
                tbGoiThau.Text = selectedRow.Cells[6].Value.ToString();
                tbNhomThau.Text = selectedRow.Cells[7].Value.ToString();
                tbSoQuyetDinh.Text = selectedRow.Cells[5].Value.ToString();
            }
            catch
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.CurrentRow;
            lbState.Text = "";
            tbGoiThau.Text = selectedRow.Cells[6].Value.ToString();
            tbNhomThau.Text = selectedRow.Cells[7].Value.ToString();
            tbSoQuyetDinh.Text = selectedRow.Cells[5].Value.ToString();
        }
        private void format_Dongia_Column()
        {
            try
            {
                dataGridView1.Columns[4].DefaultCellStyle.Format = "0.####";
            }
            catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = this.dataGridView1.CurrentRow;
        
                load_bindingData();
            try
            {
                DAOImplement_UpdateVatTu.update_thongtin_thau(Current_VatTu.DVTT, Current_VatTu.TenVatTu, Current_VatTu.MaHoatChat, Current_VatTu.MaDuongDung, Current_VatTu.SoDK, Current_VatTu.DonGia, Current_VatTu.SoQuyetDinh, Current_VatTu.GoiThau, Current_VatTu.NhomThau, Current_VatTu.SoCVBHXH);

                lbState.Text = "Đã Cập nhật thành công";
                Current_VatTu.DaCapNhap = 1;
                updateMainForm();
            } catch
            {
                lbState.Text = "Kiểm tra lại kết nối đến db, chưa cập nhập được";
            }
            
        }
        private void load_bindingData()
        {
            Current_VatTu.GoiThau = tbGoiThau.Text.Trim();
            Current_VatTu.NhomThau = tbNhomThau.Text.Trim();
            Current_VatTu.SoQuyetDinh = tbSoQuyetDinh.Text.Trim();
            Current_VatTu.SoCVBHXH = tbSoCVBHXH.Text.Trim();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            loadDataGridView();
            lbStateSearch.Text = "Dữ liệu tìm kiếm trong BHXH như bảng dưới: " + dataGridView1.RowCount + " kết quả";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbGoiThau.Text = "";
            tbNhomThau.Text = "";
            tbSoCVBHXH.Text = "";
            tbSoQuyetDinh.Text = "";
        }
    }
}

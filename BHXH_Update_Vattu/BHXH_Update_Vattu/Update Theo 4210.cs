using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BHXH_Update_Vattu.DAO;
using BHXH_Update_Vattu.Logic;
namespace BHXH_Update_Vattu
{
    public partial class Form1 : Form
    {
        private Form loginForm;
        private string dvtt;
        private VatTu current_vattu;
        formUpdate updateForm;
        public Form1()
        {
            InitializeComponent();
            // enableControls(false);
           
            dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
          //  dataGridView1.Cell
            current_vattu = new VatTu();
            handle_radiobutton();
            //bindAutoCompleteTextbox();
           
        }

        private void handle_radiobutton()
        {
            
            radioButton1.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton2.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton3.CheckedChanged += new EventHandler(radioButton_CheckedChanged);
            radioButton1.Select();
        }



        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void bindingTenLoaiVaTuToComboBox()
        {
            cbLoaiVatTu.DataSource = DAOImplement_GetDataSource.getLoaiVatTu(this.dvtt);
            cbLoaiVatTu.DisplayMember = "TENLOAIVATTU";
            cbLoaiVatTu.ValueMember = "MALOAIVATTU";
            cbLoaiVatTu.SelectedIndex = 0;
        }
        private void bindingNhomVatTuToComboBox()
        {
            string current_maloaivattu = ((DataRowView)cbLoaiVatTu.SelectedItem).Row[0].ToString();

            cbNhomVatTu.DataSource = DAOImplement_GetDataSource.getNhomVatTu(this.dvtt, current_maloaivattu);
            cbNhomVatTu.DisplayMember = "TENNHOMVATTU";
            cbNhomVatTu.ValueMember = "MANHOMVATTU";
        }
        private void bindComboBoxData()
        {
            //current_vattu = new VatTu();

            bindingTenLoaiVaTuToComboBox();
            bindingNhomVatTuToComboBox();
            current_vattu.MaLoaiVatTu = ((DataRowView)cbLoaiVatTu.SelectedItem).Row[0].ToString();
            current_vattu.MaNhomVatTu = ((DataRowView)cbNhomVatTu.SelectedItem).Row[0].ToString();
            cbTrangThai.SelectedIndex = 0;
        }

        private void btLogin_Click_1(object sender, EventArgs e) {

            generateLoginForm();

            //f_login.Show();
        }
        private void generateLoginForm()
        {

            LoginForm fControl = new LoginForm();
            fControl.DangNhapHandler += handle_login;

            loginForm = new Form();
            loginForm.Controls.Add(fControl);
            loginForm.StartPosition = FormStartPosition.CenterParent;
            loginForm.ShowDialog();
        }
        private int handle_login(string _dvtt, string _matkhau)
        {
            Boolean isLoginSuccess = DAOImplement_CheckLoginDVTT.isLoginSuccess(_dvtt, _matkhau);
            if (isLoginSuccess)
            {
               
                this.dvtt = _dvtt;
                enableControls(true);
                
                this.lbLoginState.Text = $"Đã đăng nhập:  {this.dvtt}";
                dataGridView1.DataSource = null;
                dataGridView2.DataSource = null;
                clearTextbox();
                bindAutoCompleteTextbox();
                bindComboBoxData();
                loginForm.Close();

                return 0;
            }

            return 1;

        }
        private void enableControls(Boolean state)
        {
            tableLayoutPanel2.Enabled = state;


        }
        private void bindAutoCompleteTextbox()
        {
            tbTenthuoc.AutoCompleteStringCollection = DAOImplement_GetAutoCompleteStringCollection.get_tenvattu(this.dvtt,current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu,current_vattu.TamNgung, current_vattu.DaCapNhap);
            tbMahoatchat.AutoCompleteStringCollection = DAOImplement_GetAutoCompleteStringCollection.get_mahoatchat(this.dvtt, current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu, current_vattu.TamNgung, current_vattu.DaCapNhap);
            tbMaduongdung.AutoCompleteStringCollection = DAOImplement_GetAutoCompleteStringCollection.get_maduongdung(this.dvtt, current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu, current_vattu.TamNgung, current_vattu.DaCapNhap);
            tbSodk.AutoCompleteStringCollection = DAOImplement_GetAutoCompleteStringCollection.get_sodk(this.dvtt, current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu, current_vattu.TamNgung, current_vattu.DaCapNhap);
            tbDongia.AutoCompleteStringCollection = DAOImplement_GetAutoCompleteStringCollection.get_dongia(this.dvtt, current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu, current_vattu.TamNgung, current_vattu.DaCapNhap);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            lbState01.Text = "Đang tìm kiếm trong dữ liệu bệnh viện";
             current_vattu.TenVatTu = tbTenthuoc.Text.Trim();
             current_vattu.MaHoatChat = tbMahoatchat.Text.Trim();
             current_vattu.MaDuongDung = tbMaduongdung.Text.Trim();
             current_vattu.SoDK = tbSodk.Text.Trim();

            double dongia = -1;

            try
            {
                dongia = double.Parse(tbDongia.Text.Trim());
            }
            catch
            {

            }
            current_vattu.DonGia = dongia;
            
             dataGridView1.DataSource = DAOImplement_GetDataSource.getVatTu_BV(this.dvtt, current_vattu.TenVatTu, 
                                                                     current_vattu.MaHoatChat, current_vattu.MaDuongDung, 
                                                                     current_vattu.SoDK, current_vattu.DonGia, current_vattu.TamNgung, current_vattu.DaCapNhap, current_vattu.MaLoaiVatTu, current_vattu.MaNhomVatTu);
            format_Dongia01_Column();
            lbState01.Text = "Dữ liệu tương ứng trong bệnh viện: " + dataGridView1.RowCount + " kết quả";
             dataGridView2.DataSource = DAOImplement_GetDataSource.getVatTu_BHXH(current_vattu.TenVatTu,
                                                                     current_vattu.MaHoatChat, current_vattu.MaDuongDung,
                                                                     current_vattu.SoDK, current_vattu.DonGia);
            lbState02.Text = "Dữ liệu tương ứng từ bảo hiểm xã hội như bảng dưới: " + dataGridView2.RowCount + " kết quả";
            format_Dongia02_Column();

        }
       

        private void label7_Click(object sender, EventArgs e)
        {

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dataGridView1.CurrentRow;
            current_vattu.DVTT = this.dvtt;
            current_vattu.TenVatTu = row.Cells[0].Value.ToString();
            current_vattu.MaHoatChat = row.Cells[1].Value.ToString();
            current_vattu.MaDuongDung = row.Cells[2].Value.ToString();
            current_vattu.SoDK = row.Cells[3].Value.ToString();
            current_vattu.SoQuyetDinh = row.Cells[5].Value.ToString();
            
            double dongia = 0;
            //int.TryParse(bhxh_row.Cells[4].Value.ToString(), out dongia );
            double.TryParse(row.Cells[4].Value.ToString().Replace(",", ""), out dongia);
            current_vattu.DonGia = dongia;

            if (row.Cells[6].Value.ToString() == "đã cập nhập") {
                current_vattu.DaCapNhap = 1;
            }
            else
            {
                current_vattu.DaCapNhap = 0;
            }

            current_vattu.GoiThau = row.Cells[7].Value.ToString();
            current_vattu.NhomThau = row.Cells[8].Value.ToString();
            current_vattu.SoQuyetDinh_CapNhap = row.Cells[9].Value.ToString();
            current_vattu.SoCVBHXH = row.Cells[10].Value.ToString();
             updateForm = new formUpdate(this.current_vattu);
            updateForm.updateMainForm = this.handle_updateMainForm;
           // updateForm.Current_VatTu = this.current_vattu;
            updateForm.ShowDialog();
            
           // current_vattu.SoQuyetDinh = row.Cells[5].Value.ToString();
            //current_vattu.GoiThau = row.Cells[6].Value.ToString();
           // current_vattu.NhomThau = row.Cells[7].Value.ToString();

            //current_vattu.SoCVBHXH = tbSoCVBHXH.Text.Trim();

        }
        private void handle_updateMainForm()
        {
            //dataGridView1.DataSource = DAOImplement_GetDataSource.getVatTu_BV(this.dvtt, current_vattu.TenVatTu,
            //                                                        current_vattu.MaHoatChat, current_vattu.MaDuongDung,
            //                                                        current_vattu.SoDK, current_vattu.DonGia, current_vattu.TamNgung, current_vattu.DaCapNhap, current_vattu.MaLoaiVatTu, current_vattu.MaLoaiVatTu);
            dataGridView1.CurrentRow.Cells[6].Value = "đã cập nhập";
            dataGridView1.CurrentRow.Cells[7].Value = current_vattu.GoiThau;
            dataGridView1.CurrentRow.Cells[8].Value = current_vattu.NhomThau;
            dataGridView1.CurrentRow.Cells[9].Value = current_vattu.SoQuyetDinh;
            dataGridView1.CurrentRow.Cells[10].Value = current_vattu.SoCVBHXH;
            updateForm.Close();
           // lbState01.Text = "Đã cập nhập thành công giá trị gói thầu, nhóm thầu như dưới";
            


        }

       async private void btUpdateVatTu_Click(object sender, EventArgs e)
        {
            //  VatTu new_vattu = new VatTu();

            // formUpdateAuto updateForm = new formUpdateAuto(new_vattu);
            //  updateForm.updateMainForm = this.handle_updateMainForm;
            // updateForm.Current_VatTu = this.current_vattu;
            //    updateForm.ShowDialog();
            btUpdateVatTu.Enabled = false;
            lbStateAuto.Text = "Đang update vật tư tương ứng 1-1 giữa dữ liệu của đơn vị và của BHXH theo 5 trường: 1.tên vật tư, 2.mã hoạt chất, 3.mã đường dùng, 4.số đăng ký, 5.đơn giá";
            //progressBar1.Enabled = true;
            progressBar1.Value = 30;
            await Task.Run(()=>DAOImplement_UpdateVatTu.auto_update_thongtin_thau_one_one(this.dvtt));
            lbStateAuto.Text = "đã cập nhâp thành công vật tư tương ứng 1-1 giữa dữ liệu của đơn vị và của BHXH theo 5 trường: 1.tên vật tư, 2.mã hoạt chất, 3.mã đường dùng, 4.số đăng ký, 5.đơn giá";
            progressBar1.Value = 100;
            btUpdateVatTu.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbNhomVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            current_vattu.MaNhomVatTu = ((DataRowView)cbNhomVatTu.SelectedItem).Row[0].ToString();
            bindAutoCompleteTextbox();

        }

        private void cbLoaiVatTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoaiVatTu.SelectedItem != null)
            {
                current_vattu.MaLoaiVatTu = ((DataRowView)cbLoaiVatTu.SelectedItem).Row[0].ToString();
               
            }
            bindingNhomVatTuToComboBox();
            bindAutoCompleteTextbox();
        }

        private void cbTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTrangThai.SelectedItem != null)
            {
               // current_vattu.TamNgung = int.Parse(((DataRowView)cbTrangThai.SelectedItem).Row[0].ToString());
               if (cbTrangThai.SelectedIndex == 0)
                {
                    current_vattu.TamNgung = -1;
                }
               else if (cbTrangThai.SelectedIndex == 1)
                {
                    current_vattu.TamNgung = 0;
                }
                else
                {
                    current_vattu.TamNgung = 1;
                }

            }
            bindAutoCompleteTextbox();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton current_radioButton = (RadioButton)sender;
            if(current_radioButton.Text=="Tất cả")
            {
                current_vattu.DaCapNhap = -1;
            }
            else if(current_radioButton.Text =="Chưa cập nhập")
            {
                current_vattu.DaCapNhap = 0;
            }
            else
            {
                current_vattu.DaCapNhap = 1;
            }
           
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            clearTextbox();

        }
        private void clearTextbox()
        {
            tbTenthuoc.Text = "";
            tbMahoatchat.Text = "";
            tbMaduongdung.Text = "";
            tbSodk.Text = "";
            tbDongia.Text = "";
            lbState01.Text = "";
            dataGridView1.DataSource = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // progressBar1.Enabled = false;
            generateLoginForm();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void format_Dongia01_Column()
        {
            dataGridView1.Columns[4].DefaultCellStyle.Format = "0.####";
        }
        private void format_Dongia02_Column()
        {
            dataGridView2.Columns[4].DefaultCellStyle.Format = "0.####";
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generateLoginForm();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("THÔNG BÁO", "BẠN MUỐN ĐÓNG FORM?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                //this.Close();
                e.Cancel = false;
            }
            else
            {
                //xử lí khác
                e.Cancel = true;
            }
        }


    }
}

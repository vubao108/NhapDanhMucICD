namespace NhapDanhMucIICD.View
{
    partial class FormCauhinhLoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvQuytac = new System.Windows.Forms.DataGridView();
            this.tbTen = new System.Windows.Forms.TextBox();
            this.tbMota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btThem = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuytac)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuytac
            // 
            this.dgvQuytac.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuytac.Location = new System.Drawing.Point(12, 101);
            this.dgvQuytac.Name = "dgvQuytac";
            this.dgvQuytac.Size = new System.Drawing.Size(686, 150);
            this.dgvQuytac.TabIndex = 0;
            // 
            // tbTen
            // 
            this.tbTen.Location = new System.Drawing.Point(107, 12);
            this.tbTen.Name = "tbTen";
            this.tbTen.Size = new System.Drawing.Size(581, 20);
            this.tbTen.TabIndex = 1;
            // 
            // tbMota
            // 
            this.tbMota.Location = new System.Drawing.Point(107, 46);
            this.tbMota.Name = "tbMota";
            this.tbMota.Size = new System.Drawing.Size(581, 20);
            this.tbMota.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Quy Tắc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô Tả";
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(25, 275);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(75, 23);
            this.btThem.TabIndex = 3;
            this.btThem.Text = "Thêm mới";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.button1_Click);
            // 
            // btLuu
            // 
            this.btLuu.Location = new System.Drawing.Point(126, 275);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(75, 23);
            this.btLuu.TabIndex = 3;
            this.btLuu.Text = "Lưu lại";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(234, 275);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(75, 23);
            this.btSua.TabIndex = 3;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(359, 275);
            this.btXoa.Name = "btXoa";
            this.btXoa.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btXoa.Size = new System.Drawing.Size(75, 23);
            this.btXoa.TabIndex = 3;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(107, 77);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(581, 20);
            this.tbID.TabIndex = 1;
            // 
            // FormCauhinhLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 317);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btSua);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.tbMota);
            this.Controls.Add(this.tbTen);
            this.Controls.Add(this.dgvQuytac);
            this.Name = "FormCauhinhLoi";
            this.Text = "FormCauhinhLoi";
            this.Load += new System.EventHandler(this.FormCauhinhLoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuytac)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuytac;
        private System.Windows.Forms.TextBox tbTen;
        private System.Windows.Forms.TextBox tbMota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbID;
    }
}
namespace NhapDanhMucIICD
{
    partial class MainForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btLoi = new System.Windows.Forms.Button();
            this.btICD = new System.Windows.Forms.Button();
            this.formDangNhap = new NhapDanhMucIICD.FormDangNhap();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.formDangNhap, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.27586F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.72414F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(275, 365);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btLoi);
            this.panel1.Controls.Add(this.btICD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 183);
            this.panel1.TabIndex = 3;
            // 
            // btLoi
            // 
            this.btLoi.Enabled = false;
            this.btLoi.Location = new System.Drawing.Point(72, 86);
            this.btLoi.Name = "btLoi";
            this.btLoi.Size = new System.Drawing.Size(136, 23);
            this.btLoi.TabIndex = 1;
            this.btLoi.Text = "Cấu hình thông báo lỗi";
            this.btLoi.UseVisualStyleBackColor = true;
            this.btLoi.Click += new System.EventHandler(this.btLoi_Click);
            // 
            // btICD
            // 
            this.btICD.Enabled = false;
            this.btICD.Location = new System.Drawing.Point(72, 15);
            this.btICD.Name = "btICD";
            this.btICD.Size = new System.Drawing.Size(136, 23);
            this.btICD.TabIndex = 2;
            this.btICD.Text = "Cấu hình ICD";
            this.btICD.UseVisualStyleBackColor = true;
            this.btICD.Click += new System.EventHandler(this.btICD_Click);
            // 
            // formDangNhap
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.formDangNhap, 2);
            this.formDangNhap.Location = new System.Drawing.Point(3, 3);
            this.formDangNhap.Name = "formDangNhap";
            this.formDangNhap.Size = new System.Drawing.Size(269, 170);
            this.formDangNhap.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 365);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btLoi;
        private System.Windows.Forms.Button btICD;
        private System.Windows.Forms.Panel panel1;
        private FormDangNhap formDangNhap;
    }
}
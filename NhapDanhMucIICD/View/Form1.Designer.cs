namespace NhapDanhMucIICD
{
    partial class Form1
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
            this.tcDanhMuc = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbICD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_icd_dachon = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tcDanhMuc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tcDanhMuc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbICD, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lb_icd_dachon, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 341);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tcDanhMuc
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.tcDanhMuc, 2);
            this.tcDanhMuc.Controls.Add(this.tabPage2);
            this.tcDanhMuc.Controls.Add(this.tabPage3);
            this.tcDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDanhMuc.Location = new System.Drawing.Point(3, 59);
            this.tcDanhMuc.Name = "tcDanhMuc";
            this.tcDanhMuc.SelectedIndex = 0;
            this.tcDanhMuc.Size = new System.Drawing.Size(499, 279);
            this.tcDanhMuc.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 253);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xét nghiệm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(491, 253);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "chẩn đoán hình ảnh";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbICD
            // 
            this.tbICD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbICD.Location = new System.Drawing.Point(63, 3);
            this.tbICD.Name = "tbICD";
            this.tbICD.Size = new System.Drawing.Size(439, 20);
            this.tbICD.TabIndex = 2;
            this.tbICD.TextChanged += new System.EventHandler(this.tbICD_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Đã chọn: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn ICD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_icd_dachon
            // 
            this.lb_icd_dachon.AutoSize = true;
            this.lb_icd_dachon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_icd_dachon.Location = new System.Drawing.Point(63, 27);
            this.lb_icd_dachon.Name = "lb_icd_dachon";
            this.lb_icd_dachon.Size = new System.Drawing.Size(439, 29);
            this.lb_icd_dachon.TabIndex = 6;
            this.lb_icd_dachon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(36, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 1);
            this.button2.TabIndex = 3;
            this.button2.Text = "Chon ICD";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 341);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tcDanhMuc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        



        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tcDanhMuc;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_icd_dachon;
        private System.Windows.Forms.TextBox tbICD;
    }
}


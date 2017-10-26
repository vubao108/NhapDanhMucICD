using System.Windows.Forms;

namespace NhapDanhMucIICD
{
    partial class ThemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvDanhmuctong = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvXNdachon = new System.Windows.Forms.DataGridView();
            this.lbThemResult = new System.Windows.Forms.Label();
            this.btThem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhmuctong)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXNdachon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(576, 384);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.dgvDanhmuctong);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(568, 358);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh mục icd-xét nghiệm";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvDanhmuctong
            // 
            this.dgvDanhmuctong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhmuctong.Location = new System.Drawing.Point(3, 3);
            this.dgvDanhmuctong.Name = "dgvDanhmuctong";
            this.dgvDanhmuctong.Size = new System.Drawing.Size(560, 350);
            this.dgvDanhmuctong.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(568, 358);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Đã có";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(568, 358);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Thêm mới";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvXNdachon, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbThemResult, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btThem, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(562, 352);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvXNdachon
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.dgvXNdachon, 2);
            this.dgvXNdachon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvXNdachon.Location = new System.Drawing.Point(3, 72);
            this.dgvXNdachon.Name = "dgvXNdachon";
            this.dgvXNdachon.Size = new System.Drawing.Size(556, 277);
            this.dgvXNdachon.TabIndex = 0;
            // 
            // lbThemResult
            // 
            this.lbThemResult.AutoSize = true;
            this.lbThemResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbThemResult.Location = new System.Drawing.Point(83, 27);
            this.lbThemResult.Name = "lbThemResult";
            this.lbThemResult.Size = new System.Drawing.Size(476, 42);
            this.lbThemResult.TabIndex = 1;
            this.lbThemResult.Text = "...";
            this.lbThemResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbThemResult.Click += new System.EventHandler(this.label1_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(3, 30);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(74, 36);
            this.btThem.TabIndex = 2;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tìm XN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView3
            // 
            this.dataGridView3.Location = new System.Drawing.Point(0, 0);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(240, 150);
            this.dataGridView3.TabIndex = 0;
            // 
            // ThemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ThemControl";
            this.Size = new System.Drawing.Size(576, 384);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhmuctong)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXNdachon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvDanhmuctong;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvXNdachon;
        private System.Windows.Forms.Label lbThemResult;
        private System.Windows.Forms.Button btThem;
        private Label label2;

        public DataGridView DgvDanhmuctong { get => dgvDanhmuctong;  private set => dgvDanhmuctong = value; }
        public DataGridView DataGridView3 { get => dataGridView3; private set => dataGridView3 = value; }
        public DataGridView DgvXNdachon { get => dgvXNdachon; private set => dgvXNdachon = value; }
    }
}

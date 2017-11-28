namespace CookieLogin
{
    partial class FormCookieLoginAndGetData
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
            this.btGetData = new System.Windows.Forms.Button();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tbBreak = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbState = new System.Windows.Forms.Label();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTongso = new System.Windows.Forms.Label();
            this.btRefresh = new System.Windows.Forms.Button();
            this.tbCellContent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(428, 35);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(101, 23);
            this.btGetData.TabIndex = 0;
            this.btGetData.Text = "Lay Du Lieu";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 61);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1047, 316);
            this.dgv.TabIndex = 1;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // tbBreak
            // 
            this.tbBreak.Location = new System.Drawing.Point(970, 9);
            this.tbBreak.Name = "tbBreak";
            this.tbBreak.Size = new System.Drawing.Size(61, 20);
            this.tbBreak.TabIndex = 2;
            this.tbBreak.Text = "20";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(839, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số lần lặp trước khi dừng";
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.Location = new System.Drawing.Point(48, 385);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(32, 13);
            this.lbState.TabIndex = 4;
            this.lbState.Text = "State";
            this.lbState.Click += new System.EventHandler(this.lbState_Click);
            // 
            // tbNum
            // 
            this.tbNum.Location = new System.Drawing.Point(970, 35);
            this.tbNum.Name = "tbNum";
            this.tbNum.Size = new System.Drawing.Size(61, 20);
            this.tbNum.TabIndex = 5;
            this.tbNum.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(851, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số phần tử trong bảng";
            // 
            // lbTongso
            // 
            this.lbTongso.AutoSize = true;
            this.lbTongso.Location = new System.Drawing.Point(886, 380);
            this.lbTongso.Name = "lbTongso";
            this.lbTongso.Size = new System.Drawing.Size(88, 13);
            this.lbTongso.TabIndex = 7;
            this.lbTongso.Text = "Tổng số văn bản";
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(757, 35);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 8;
            this.btRefresh.Text = "Làm mới";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // tbCellContent
            // 
            this.tbCellContent.AutoSize = true;
            this.tbCellContent.Location = new System.Drawing.Point(12, 407);
            this.tbCellContent.Name = "tbCellContent";
            this.tbCellContent.Size = new System.Drawing.Size(35, 13);
            this.tbCellContent.TabIndex = 9;
            this.tbCellContent.Text = "label2";
            // 
            // FormCookieLoginAndGetData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 462);
            this.Controls.Add(this.tbCellContent);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.lbTongso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNum);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbBreak);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.btGetData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCookieLoginAndGetData";
            this.Text = "FormCookieLoginAndGetData";
            this.Load += new System.EventHandler(this.FormCookieLoginAndGetData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox tbBreak;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbState;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTongso;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Label tbCellContent;
    }
}
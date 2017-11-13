namespace ExcelWinform
{
    partial class ExcelWinform
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
            this.btConvert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.btText = new System.Windows.Forms.Button();
            this.btExcel = new System.Windows.Forms.Button();
            this.lbText = new System.Windows.Forms.Label();
            this.lbExcel = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRowStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConvert
            // 
            this.btConvert.Location = new System.Drawing.Point(127, 178);
            this.btConvert.Name = "btConvert";
            this.btConvert.Size = new System.Drawing.Size(75, 23);
            this.btConvert.TabIndex = 0;
            this.btConvert.Text = "Convert To Excel BHYT";
            this.btConvert.UseVisualStyleBackColor = true;
            this.btConvert.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // btText
            // 
            this.btText.Location = new System.Drawing.Point(55, 48);
            this.btText.Name = "btText";
            this.btText.Size = new System.Drawing.Size(92, 23);
            this.btText.TabIndex = 1;
            this.btText.Text = "Text File Path";
            this.btText.UseVisualStyleBackColor = true;
            this.btText.Click += new System.EventHandler(this.btText_Click);
            // 
            // btExcel
            // 
            this.btExcel.Location = new System.Drawing.Point(234, 48);
            this.btExcel.Name = "btExcel";
            this.btExcel.Size = new System.Drawing.Size(96, 23);
            this.btExcel.TabIndex = 2;
            this.btExcel.Text = "xlsx File Path";
            this.btExcel.UseVisualStyleBackColor = true;
            this.btExcel.Click += new System.EventHandler(this.btExcel_Click);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(55, 29);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(35, 13);
            this.lbText.TabIndex = 3;
            this.lbText.Text = "label1";
            // 
            // lbExcel
            // 
            this.lbExcel.AutoSize = true;
            this.lbExcel.Location = new System.Drawing.Point(234, 29);
            this.lbExcel.Name = "lbExcel";
            this.lbExcel.Size = new System.Drawing.Size(35, 13);
            this.lbExcel.TabIndex = 4;
            this.lbExcel.Text = "label2";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Location = new System.Drawing.Point(143, 220);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(35, 13);
            this.lbResult.TabIndex = 5;
            this.lbResult.Text = "label3";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sheet Num";
            // 
            // tbRowStart
            // 
            this.tbRowStart.Location = new System.Drawing.Point(234, 104);
            this.tbRowStart.Name = "tbRowStart";
            this.tbRowStart.Size = new System.Drawing.Size(100, 20);
            this.tbRowStart.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "From Row Num";
            // 
            // ExcelWinform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 301);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbRowStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.lbExcel);
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.btExcel);
            this.Controls.Add(this.btText);
            this.Controls.Add(this.btConvert);
            this.Name = "ExcelWinform";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConvert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button btText;
        private System.Windows.Forms.Button btExcel;
        private System.Windows.Forms.Label lbText;
        private System.Windows.Forms.Label lbExcel;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRowStart;
        private System.Windows.Forms.Label label2;
    }
}


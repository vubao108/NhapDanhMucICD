namespace WindowsFormsSelenium
{
    partial class WinformSelenium
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
            this.button1 = new System.Windows.Forms.Button();
            this.btXuly = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPage = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            this.btUrl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btXuly
            // 
            this.btXuly.Location = new System.Drawing.Point(150, 142);
            this.btXuly.Name = "btXuly";
            this.btXuly.Size = new System.Drawing.Size(75, 23);
            this.btXuly.TabIndex = 1;
            this.btXuly.Text = "Xu Ly";
            this.btXuly.UseVisualStyleBackColor = true;
            this.btXuly.Click += new System.EventHandler(this.btXuly_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "page:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbPage
            // 
            this.lbPage.AutoSize = true;
            this.lbPage.Location = new System.Drawing.Point(147, 21);
            this.lbPage.Name = "lbPage";
            this.lbPage.Size = new System.Drawing.Size(13, 13);
            this.lbPage.TabIndex = 3;
            this.lbPage.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(147, 57);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(13, 13);
            this.lbCount.TabIndex = 3;
            this.lbCount.Text = "1";
            // 
            // btUrl
            // 
            this.btUrl.Location = new System.Drawing.Point(84, 198);
            this.btUrl.Name = "btUrl";
            this.btUrl.Size = new System.Drawing.Size(75, 23);
            this.btUrl.TabIndex = 5;
            this.btUrl.Text = "Lay URL file";
            this.btUrl.UseVisualStyleBackColor = true;
            this.btUrl.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lbPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btXuly);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btXuly;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.Button btUrl;
    }
}


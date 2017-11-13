namespace WindowsFormsApp1
{
    partial class SeleniumGetCookie
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
            this.btStart = new System.Windows.Forms.Button();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGetCookie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbGetRequest = new System.Windows.Forms.TextBox();
            this.tbHtml = new System.Windows.Forms.TextBox();
            this.btGetRequest = new System.Windows.Forms.Button();
            this.btGetData = new System.Windows.Forms.Button();
            this.tbSheet = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPostData = new System.Windows.Forms.TextBox();
            this.btPOST = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(45, 83);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 0;
            this.btStart.Text = "Login";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.UseWaitCursor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(45, 30);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(550, 20);
            this.tbAddress.TabIndex = 1;
            this.tbAddress.Text = "http://daotaogdbhyt.baohiemxahoi.gov.vn/Account/Index";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link";
            // 
            // btGetCookie
            // 
            this.btGetCookie.Location = new System.Drawing.Point(185, 83);
            this.btGetCookie.Name = "btGetCookie";
            this.btGetCookie.Size = new System.Drawing.Size(75, 23);
            this.btGetCookie.TabIndex = 3;
            this.btGetCookie.Text = "Get Cookie";
            this.btGetCookie.UseVisualStyleBackColor = true;
            this.btGetCookie.Click += new System.EventHandler(this.GetCookie_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Get";
            // 
            // tbGetRequest
            // 
            this.tbGetRequest.Location = new System.Drawing.Point(45, 159);
            this.tbGetRequest.Name = "tbGetRequest";
            this.tbGetRequest.Size = new System.Drawing.Size(550, 20);
            this.tbGetRequest.TabIndex = 1;
            this.tbGetRequest.Text = "http://daotaogdbhyt.baohiemxahoi.gov.vn/DM_GOITHAUCHITIET/Index/6973";
            // 
            // tbHtml
            // 
            
            this.tbHtml.Location = new System.Drawing.Point(45, 246);
            this.tbHtml.Multiline = true;
            this.tbHtml.Name = "tbHtml";
            this.tbHtml.Size = new System.Drawing.Size(550, 229);
            this.tbHtml.TabIndex = 5;
            // 
            // btGetRequest
            // 
            this.btGetRequest.Location = new System.Drawing.Point(45, 204);
            this.btGetRequest.Name = "btGetRequest";
            this.btGetRequest.Size = new System.Drawing.Size(75, 23);
            this.btGetRequest.TabIndex = 3;
            this.btGetRequest.Text = "Get Request";
            this.btGetRequest.UseVisualStyleBackColor = true;
            this.btGetRequest.Click += new System.EventHandler(this.GetRequest_Click);
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(185, 204);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(146, 23);
            this.btGetData.TabIndex = 6;
            this.btGetData.Text = "Get Data With Selenium";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // tbSheet
            // 
            this.tbSheet.Location = new System.Drawing.Point(467, 206);
            this.tbSheet.Name = "tbSheet";
            this.tbSheet.Size = new System.Drawing.Size(100, 20);
            this.tbSheet.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "PostData";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tbPostData
            // 
            this.tbPostData.Location = new System.Drawing.Point(601, 46);
            this.tbPostData.Multiline = true;
            this.tbPostData.Name = "tbPostData";
            this.tbPostData.Size = new System.Drawing.Size(311, 429);
            this.tbPostData.TabIndex = 5;
            // 
            // btPOST
            // 
            this.btPOST.Location = new System.Drawing.Point(718, 20);
            this.btPOST.Name = "btPOST";
            this.btPOST.Size = new System.Drawing.Size(75, 23);
            this.btPOST.TabIndex = 3;
            this.btPOST.Text = "POST";
            this.btPOST.UseVisualStyleBackColor = true;
            this.btPOST.Click += new System.EventHandler(this.btPOST_Click);
            // 
            // SeleniumGetCookie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 487);
            this.Controls.Add(this.tbSheet);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.tbPostData);
            this.Controls.Add(this.tbHtml);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btGetRequest);
            this.Controls.Add(this.btPOST);
            this.Controls.Add(this.btGetCookie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbGetRequest);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.btStart);
            this.Name = "SeleniumGetCookie";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGetCookie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbGetRequest;
        private System.Windows.Forms.TextBox tbHtml;
        private System.Windows.Forms.Button btGetRequest;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.TextBox tbSheet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPostData;
        private System.Windows.Forms.Button btPOST;
    }
}


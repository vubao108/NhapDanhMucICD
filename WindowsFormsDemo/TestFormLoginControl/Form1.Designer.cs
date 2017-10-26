namespace TestFormLoginControl
{
    partial class TestLoginControl
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
            this.loginControl1 = new SubmitButton.LoginControl();
            this.loginControl1.LoginSuccess += loginSuccessHandler;
            this.loginControl1.LoginFailed += loginFailedHandler;
            this.SuspendLayout();
            // 
            // loginControl1
            // 
            this.loginControl1.LabelName = "Name";
            this.loginControl1.Location = new System.Drawing.Point(12, 12);
            this.loginControl1.LoginButtonText = "Login";
            this.loginControl1.Name = "loginControl1";
            this.loginControl1.Size = new System.Drawing.Size(260, 154);
            this.loginControl1.TabIndex = 0;
            // 
            // TestLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.loginControl1);
            this.Name = "TestLoginControl";
            this.Text = "TestLoginControl";
            this.ResumeLayout(false);

        }

        #endregion

        private SubmitButton.LoginControl loginControl1;
        
    }
}


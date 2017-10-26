namespace TestApp
{
    partial class TestForm
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
            this.submitButtonControl = new SubmitButton.SubmitButton();
            this.SuspendLayout();
            // 
            // submitButtonControl
            // 
            this.submitButtonControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitButtonControl.Location = new System.Drawing.Point(0, 0);
            this.submitButtonControl.Name = "submitButtonControl";
            this.submitButtonControl.Size = new System.Drawing.Size(482, 261);
            this.submitButtonControl.TabIndex = 0;
            this.submitButtonControl.UserName = "";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 261);
            this.Controls.Add(this.submitButtonControl);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SubmitButton.SubmitButton submitButtonControl;
    }
}


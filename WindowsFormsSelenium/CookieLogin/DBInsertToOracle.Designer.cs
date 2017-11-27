namespace CookieLogin
{
    partial class DBInsertToOracle
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
            this.tbUpdateOracle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUpdateOracle
            // 
            this.tbUpdateOracle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbUpdateOracle.Location = new System.Drawing.Point(0, 0);
            this.tbUpdateOracle.Name = "tbUpdateOracle";
            this.tbUpdateOracle.Size = new System.Drawing.Size(159, 66);
            this.tbUpdateOracle.TabIndex = 0;
            this.tbUpdateOracle.Text = "UpdateOracle";
            this.tbUpdateOracle.UseVisualStyleBackColor = true;
            this.tbUpdateOracle.Click += new System.EventHandler(this.btUpdateOracle_Click);
            // 
            // DBInsertToOracle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbUpdateOracle);
            this.Name = "DBInsertToOracle";
            this.Size = new System.Drawing.Size(159, 66);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tbUpdateOracle;
    }
}

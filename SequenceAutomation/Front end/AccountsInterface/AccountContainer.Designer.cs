namespace SequenceAutomation
{
    partial class AccountContainer
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
            this.options = new SequenceAutomation.Options();
            this.login1 = new SequenceAutomation.Login();
            this.register1 = new SequenceAutomation.Register();
            this.SuspendLayout();
            // 
            // options
            // 
            this.options.BackColor = System.Drawing.Color.MintCream;
            this.options.Location = new System.Drawing.Point(1, 3);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(860, 458);
            this.options.TabIndex = 0;
            // 
            // login1
            // 
            this.login1.BackColor = System.Drawing.Color.MintCream;
            this.login1.Location = new System.Drawing.Point(1, 3);
            this.login1.Name = "login1";
            this.login1.Size = new System.Drawing.Size(515, 415);
            this.login1.TabIndex = 1;
            // 
            // register1
            // 
            this.register1.BackColor = System.Drawing.Color.MintCream;
            this.register1.Location = new System.Drawing.Point(1, 3);
            this.register1.Name = "register1";
            this.register1.Size = new System.Drawing.Size(628, 723);
            this.register1.TabIndex = 2;
            // 
            // AccountContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(844, 442);
            this.Controls.Add(this.options);
            this.Controls.Add(this.login1);
            this.Controls.Add(this.register1);
            this.Name = "AccountContainer";
            this.Text = "AccountContainer";
            this.ResumeLayout(false);

        }

        #endregion

        private Options options;
        private Login login1;
        private Register register1;
    }
}
namespace SequenceAutomation
{
    partial class ApplicationContainer
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
            this.playRecUserControl = new SequenceAutomation.PlayRecUserControl();
            this.loginUserControl = new SequenceAutomation.LoginUserControl();
            this.createRecUserControl = new SequenceAutomation.CreateRecUserControl();
            this.SuspendLayout();
            // 
            // playRecUserControl
            // 
            this.playRecUserControl.BackColor = System.Drawing.SystemColors.Control;
            this.playRecUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRecUserControl.Location = new System.Drawing.Point(0, 0);
            this.playRecUserControl.Name = "playRecUserControl";
            this.playRecUserControl.Size = new System.Drawing.Size(1406, 663);
            this.playRecUserControl.TabIndex = 2;
            // 
            // loginUserControl
            // 
            this.loginUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loginUserControl.Location = new System.Drawing.Point(0, 0);
            this.loginUserControl.Name = "loginUserControl";
            this.loginUserControl.Size = new System.Drawing.Size(990, 530);
            this.loginUserControl.TabIndex = 0;
            // 
            // createRecUserControl
            // 
            this.createRecUserControl.BackColor = System.Drawing.SystemColors.Control;
            this.createRecUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.createRecUserControl.Location = new System.Drawing.Point(0, 0);
            this.createRecUserControl.Name = "createRecUserControl";
            this.createRecUserControl.Size = new System.Drawing.Size(990, 530);
            this.createRecUserControl.TabIndex = 1;
            // 
            // ApplicationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 531);
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.createRecUserControl);
            this.Controls.Add(this.playRecUserControl);
            this.Name = "ApplicationContainer";
            this.Text = "ApplicationContainer";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginUserControl loginUserControl;
        private CreateRecUserControl createRecUserControl;
        private PlayRecUserControl playRecUserControl;
    }
}
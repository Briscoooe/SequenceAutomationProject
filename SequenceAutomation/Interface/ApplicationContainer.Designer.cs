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
            this.loginUserControl = new SequenceAutomation.LoginUserControl();
            this.createRecUserControl = new SequenceAutomation.CreateRecUserControl();
            this.playRecUserControl = new SequenceAutomation.PlayRecUserControl();
            this.firstTimePlay = new SequenceAutomation.FirstTimePlay();
            this.tutorialSelectSpeed = new SequenceAutomation.TutorialSelectSpeed();
            this.tutorialPlayRec = new SequenceAutomation.TutorialPlayRec();
            this.tutorialSelectRec = new SequenceAutomation.TutorialSelectRec();
            this.firstTimeCreate = new SequenceAutomation.Interface.FirstTimeCreate();
            this.SuspendLayout();
            // 
            // loginUserControl
            // 
            this.loginUserControl.BackColor = System.Drawing.Color.MintCream;
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
            // playRecUserControl
            // 
            this.playRecUserControl.BackColor = System.Drawing.SystemColors.Control;
            this.playRecUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRecUserControl.Location = new System.Drawing.Point(0, 0);
            this.playRecUserControl.Name = "playRecUserControl";
            this.playRecUserControl.Size = new System.Drawing.Size(1406, 663);
            this.playRecUserControl.TabIndex = 2;
            // 
            // firstTimePlay
            // 
            this.firstTimePlay.BackColor = System.Drawing.Color.MintCream;
            this.firstTimePlay.Location = new System.Drawing.Point(0, 0);
            this.firstTimePlay.Name = "firstTimePlay";
            this.firstTimePlay.Size = new System.Drawing.Size(990, 530);
            this.firstTimePlay.TabIndex = 3;
            // 
            // tutorialSelectSpeed
            // 
            this.tutorialSelectSpeed.BackColor = System.Drawing.Color.MintCream;
            this.tutorialSelectSpeed.Location = new System.Drawing.Point(0, 0);
            this.tutorialSelectSpeed.Name = "tutorialSelectSpeed";
            this.tutorialSelectSpeed.Size = new System.Drawing.Size(955, 444);
            this.tutorialSelectSpeed.TabIndex = 6;
            // 
            // tutorialPlayRec
            // 
            this.tutorialPlayRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialPlayRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialPlayRec.Name = "tutorialPlayRec";
            this.tutorialPlayRec.Size = new System.Drawing.Size(847, 468);
            this.tutorialPlayRec.TabIndex = 5;
            // 
            // tutorialSelectRec
            // 
            this.tutorialSelectRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialSelectRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialSelectRec.Name = "tutorialSelectRec";
            this.tutorialSelectRec.Size = new System.Drawing.Size(990, 530);
            this.tutorialSelectRec.TabIndex = 4;
            // 
            // firstTimeCreate
            // 
            this.firstTimeCreate.BackColor = System.Drawing.Color.MintCream;
            this.firstTimeCreate.Location = new System.Drawing.Point(0, 0);
            this.firstTimeCreate.Name = "firstTimeCreate";
            this.firstTimeCreate.Size = new System.Drawing.Size(990, 530);
            this.firstTimeCreate.TabIndex = 7;
            // 
            // ApplicationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 531);
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.createRecUserControl);
            this.Controls.Add(this.playRecUserControl);
            this.Controls.Add(this.firstTimePlay);
            this.Controls.Add(this.tutorialSelectSpeed);
            this.Controls.Add(this.tutorialPlayRec);
            this.Controls.Add(this.tutorialSelectRec);
            this.Controls.Add(this.firstTimeCreate);
            this.Name = "ApplicationContainer";
            this.Text = "Easy Automator";
            this.ResumeLayout(false);

        }

        #endregion
        private CreateRecUserControl createRecUserControl;
        private PlayRecUserControl playRecUserControl;
        private FirstTimePlay firstTimePlay;
        private LoginUserControl loginUserControl;
        private TutorialSelectRec tutorialSelectRec;
        private TutorialPlayRec tutorialPlayRec;
        private TutorialSelectSpeed tutorialSelectSpeed;
        private Interface.FirstTimeCreate firstTimeCreate;
    }
}
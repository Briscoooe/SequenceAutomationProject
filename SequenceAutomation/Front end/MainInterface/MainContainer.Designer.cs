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
            this.tutorialPlayRec = new SequenceAutomation.TutorialPlayRec();
            this.tutorialSelectRec = new SequenceAutomation.TutorialSelectRec();
            this.firstTimeCreate = new SequenceAutomation.Interface.FirstTimeCreate();
            this.tutorialStartRec = new SequenceAutomation.TutorialStartRec();
            this.tutorialTestRec = new SequenceAutomation.Interface.TutorialTestRec();
            this.tutorialUploadRec = new SequenceAutomation.TutorialUploadRec();
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
            this.createRecUserControl.BackColor = System.Drawing.Color.MintCream;
            this.createRecUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.createRecUserControl.Location = new System.Drawing.Point(0, 0);
            this.createRecUserControl.Name = "createRecUserControl";
            this.createRecUserControl.Size = new System.Drawing.Size(1208, 612);
            this.createRecUserControl.TabIndex = 1;
            this.createRecUserControl.Tag = "startRecTag";
            // 
            // playRecUserControl
            // 
            this.playRecUserControl.BackColor = System.Drawing.Color.MintCream;
            this.playRecUserControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRecUserControl.Location = new System.Drawing.Point(0, 0);
            this.playRecUserControl.Name = "playRecUserControl";
            this.playRecUserControl.Size = new System.Drawing.Size(1270, 680);
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
            // tutorialPlayRec
            // 
            this.tutorialPlayRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialPlayRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialPlayRec.Name = "tutorialPlayRec";
            this.tutorialPlayRec.Size = new System.Drawing.Size(1325, 522);
            this.tutorialPlayRec.TabIndex = 5;
            // 
            // tutorialSelectRec
            // 
            this.tutorialSelectRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialSelectRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialSelectRec.Name = "tutorialSelectRec";
            this.tutorialSelectRec.Size = new System.Drawing.Size(1168, 690);
            this.tutorialSelectRec.TabIndex = 6;
            // 
            // firstTimeCreate
            // 
            this.firstTimeCreate.BackColor = System.Drawing.Color.MintCream;
            this.firstTimeCreate.Location = new System.Drawing.Point(0, 0);
            this.firstTimeCreate.Name = "firstTimeCreate";
            this.firstTimeCreate.Size = new System.Drawing.Size(990, 530);
            this.firstTimeCreate.TabIndex = 7;
            // 
            // tutorialStartRec
            // 
            this.tutorialStartRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialStartRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialStartRec.Name = "tutorialStartRec";
            this.tutorialStartRec.Size = new System.Drawing.Size(961, 505);
            this.tutorialStartRec.TabIndex = 8;
            // 
            // tutorialTestRec
            // 
            this.tutorialTestRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialTestRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialTestRec.Name = "tutorialTestRec";
            this.tutorialTestRec.Size = new System.Drawing.Size(961, 505);
            this.tutorialTestRec.TabIndex = 9;
            // 
            // tutorialUploadRec
            // 
            this.tutorialUploadRec.BackColor = System.Drawing.Color.MintCream;
            this.tutorialUploadRec.Location = new System.Drawing.Point(0, 0);
            this.tutorialUploadRec.Name = "tutorialUploadRec";
            this.tutorialUploadRec.Size = new System.Drawing.Size(1065, 719);
            this.tutorialUploadRec.TabIndex = 10;
            // 
            // ApplicationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 527);
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.createRecUserControl);
            this.Controls.Add(this.playRecUserControl);
            this.Controls.Add(this.firstTimePlay);
            this.Controls.Add(this.tutorialPlayRec);
            this.Controls.Add(this.tutorialSelectRec);
            this.Controls.Add(this.firstTimeCreate);
            this.Controls.Add(this.tutorialStartRec);
            this.Controls.Add(this.tutorialTestRec);
            this.Controls.Add(this.tutorialUploadRec);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private Interface.FirstTimeCreate firstTimeCreate;
        private TutorialStartRec tutorialStartRec;
        private Interface.TutorialTestRec tutorialTestRec;
        private TutorialUploadRec tutorialUploadRec;
    }
}
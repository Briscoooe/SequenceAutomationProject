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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationContainer));
            this.loginUserControl = new SequenceAutomation.LoginUserControl();
            this.createRecUserControl = new SequenceAutomation.CreateRecUserControl();
            this.playRecUserControl = new SequenceAutomation.PlayRecUserControl();
            this.firstTimePlay = new SequenceAutomation.FirstTimePlay();
            this.tutorialSelectSpeed = new SequenceAutomation.TutorialSelectSpeed();
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
            resources.ApplyResources(this.loginUserControl, "loginUserControl");
            this.loginUserControl.Name = "loginUserControl";
            // 
            // createRecUserControl
            // 
            this.createRecUserControl.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.createRecUserControl, "createRecUserControl");
            this.createRecUserControl.Name = "createRecUserControl";
            this.createRecUserControl.Tag = "startRecTag";
            // 
            // playRecUserControl
            // 
            this.playRecUserControl.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.playRecUserControl, "playRecUserControl");
            this.playRecUserControl.Name = "playRecUserControl";
            // 
            // firstTimePlay
            // 
            this.firstTimePlay.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.firstTimePlay, "firstTimePlay");
            this.firstTimePlay.Name = "firstTimePlay";
            // 
            // tutorialSelectSpeed
            // 
            this.tutorialSelectSpeed.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialSelectSpeed, "tutorialSelectSpeed");
            this.tutorialSelectSpeed.Name = "tutorialSelectSpeed";
            // 
            // tutorialPlayRec
            // 
            this.tutorialPlayRec.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialPlayRec, "tutorialPlayRec");
            this.tutorialPlayRec.Name = "tutorialPlayRec";
            // 
            // tutorialSelectRec
            // 
            this.tutorialSelectRec.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialSelectRec, "tutorialSelectRec");
            this.tutorialSelectRec.Name = "tutorialSelectRec";
            // 
            // firstTimeCreate
            // 
            this.firstTimeCreate.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.firstTimeCreate, "firstTimeCreate");
            this.firstTimeCreate.Name = "firstTimeCreate";
            // 
            // tutorialStartRec
            // 
            this.tutorialStartRec.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialStartRec, "tutorialStartRec");
            this.tutorialStartRec.Name = "tutorialStartRec";
            // 
            // tutorialTestRec
            // 
            this.tutorialTestRec.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialTestRec, "tutorialTestRec");
            this.tutorialTestRec.Name = "tutorialTestRec";
            // 
            // tutorialUploadRec
            // 
            this.tutorialUploadRec.BackColor = System.Drawing.Color.MintCream;
            resources.ApplyResources(this.tutorialUploadRec, "tutorialUploadRec");
            this.tutorialUploadRec.Name = "tutorialUploadRec";
            // 
            // ApplicationContainer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loginUserControl);
            this.Controls.Add(this.createRecUserControl);
            this.Controls.Add(this.playRecUserControl);
            this.Controls.Add(this.firstTimePlay);
            this.Controls.Add(this.tutorialSelectSpeed);
            this.Controls.Add(this.tutorialPlayRec);
            this.Controls.Add(this.tutorialSelectRec);
            this.Controls.Add(this.firstTimeCreate);
            this.Controls.Add(this.tutorialStartRec);
            this.Controls.Add(this.tutorialTestRec);
            this.Controls.Add(this.tutorialUploadRec);
            this.Name = "ApplicationContainer";
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
        private TutorialStartRec tutorialStartRec;
        private Interface.TutorialTestRec tutorialTestRec;
        private TutorialUploadRec tutorialUploadRec;
    }
}
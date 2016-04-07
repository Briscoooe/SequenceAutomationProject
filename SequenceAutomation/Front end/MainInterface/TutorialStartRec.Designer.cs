namespace SequenceAutomation
{
    partial class TutorialStartRec
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
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.recButtonLabel = new System.Windows.Forms.Label();
            this.recStatusText = new System.Windows.Forms.Label();
            this.recStatusLabel = new System.Windows.Forms.Label();
            this.recCreatedLabel = new System.Windows.Forms.Label();
            this.nextBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.recButtonLabel2 = new System.Windows.Forms.Label();
            this.startStopRecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(241, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 47);
            this.label4.TabIndex = 32;
            this.label4.Text = "Step 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(368, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 47);
            this.label2.TabIndex = 31;
            this.label2.Text = "Create the recording";
            // 
            // recButtonLabel
            // 
            this.recButtonLabel.AutoSize = true;
            this.recButtonLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recButtonLabel.Location = new System.Drawing.Point(33, 104);
            this.recButtonLabel.Name = "recButtonLabel";
            this.recButtonLabel.Size = new System.Drawing.Size(574, 37);
            this.recButtonLabel.TabIndex = 34;
            this.recButtonLabel.Text = "Press the red button to begin the recording";
            // 
            // recStatusText
            // 
            this.recStatusText.AutoSize = true;
            this.recStatusText.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recStatusText.ForeColor = System.Drawing.Color.Red;
            this.recStatusText.Location = new System.Drawing.Point(280, 429);
            this.recStatusText.Name = "recStatusText";
            this.recStatusText.Size = new System.Drawing.Size(198, 37);
            this.recStatusText.TabIndex = 36;
            this.recStatusText.Text = "Not recording";
            // 
            // recStatusLabel
            // 
            this.recStatusLabel.AutoSize = true;
            this.recStatusLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recStatusLabel.Location = new System.Drawing.Point(33, 429);
            this.recStatusLabel.Name = "recStatusLabel";
            this.recStatusLabel.Size = new System.Drawing.Size(241, 37);
            this.recStatusLabel.TabIndex = 35;
            this.recStatusLabel.Text = "Recording Status:";
            // 
            // recCreatedLabel
            // 
            this.recCreatedLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recCreatedLabel.Location = new System.Drawing.Point(585, 200);
            this.recCreatedLabel.Name = "recCreatedLabel";
            this.recCreatedLabel.Size = new System.Drawing.Size(373, 150);
            this.recCreatedLabel.TabIndex = 37;
            this.recCreatedLabel.Text = "Recording created!\r\nPress the arrow button below\r\nto test your recording\r\n";
            this.recCreatedLabel.Visible = false;
            // 
            // nextBtn
            // 
            this.nextBtn.BackColor = System.Drawing.Color.Transparent;
            this.nextBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.forwardbutton;
            this.nextBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.nextBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextBtn.FlatAppearance.BorderSize = 0;
            this.nextBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.nextBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.nextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(789, 429);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(169, 73);
            this.nextBtn.TabIndex = 30;
            this.nextBtn.UseVisualStyleBackColor = false;
            this.nextBtn.Click += new System.EventHandler(this.goNext);
            this.nextBtn.MouseEnter += new System.EventHandler(this.nextBtn_MouseEnter);
            this.nextBtn.MouseLeave += new System.EventHandler(this.nextBtn_MouseLeave);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.home;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Location = new System.Drawing.Point(848, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(110, 110);
            this.homeBtn.TabIndex = 29;
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.gotoLogin);
            this.homeBtn.MouseEnter += new System.EventHandler(this.homeBtn_MouseEnter);
            this.homeBtn.MouseLeave += new System.EventHandler(this.homeBtn_MouseLeave);
            // 
            // goBackBtn
            // 
            this.goBackBtn.BackColor = System.Drawing.Color.Transparent;
            this.goBackBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.backbutton;
            this.goBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackBtn.FlatAppearance.BorderSize = 0;
            this.goBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.goBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.goBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(3, 3);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 18;
            this.goBackBtn.UseVisualStyleBackColor = false;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
            // 
            // recButtonLabel2
            // 
            this.recButtonLabel2.AutoSize = true;
            this.recButtonLabel2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recButtonLabel2.Location = new System.Drawing.Point(33, 141);
            this.recButtonLabel2.Name = "recButtonLabel2";
            this.recButtonLabel2.Size = new System.Drawing.Size(784, 37);
            this.recButtonLabel2.TabIndex = 38;
            this.recButtonLabel2.Text = "Once pressed, all mouse and keyboard activity will be saved";
            // 
            // startStopRecBtn
            // 
            this.startStopRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.record;
            this.startStopRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startStopRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startStopRecBtn.FlatAppearance.BorderSize = 0;
            this.startStopRecBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startStopRecBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startStopRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startStopRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopRecBtn.Location = new System.Drawing.Point(103, 200);
            this.startStopRecBtn.Name = "startStopRecBtn";
            this.startStopRecBtn.Size = new System.Drawing.Size(150, 150);
            this.startStopRecBtn.TabIndex = 33;
            this.startStopRecBtn.Tag = "startRecTag";
            this.startStopRecBtn.UseVisualStyleBackColor = true;
            this.startStopRecBtn.Click += new System.EventHandler(this.startRecording);
            this.startStopRecBtn.MouseEnter += new System.EventHandler(this.startStopRecBtn_MouseEnter);
            this.startStopRecBtn.MouseLeave += new System.EventHandler(this.startStopRecBtn_MouseLeave);
            // 
            // TutorialStartRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.recButtonLabel2);
            this.Controls.Add(this.recCreatedLabel);
            this.Controls.Add(this.recStatusText);
            this.Controls.Add(this.recStatusLabel);
            this.Controls.Add(this.recButtonLabel);
            this.Controls.Add(this.startStopRecBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.goBackBtn);
            this.Name = "TutorialStartRec";
            this.Size = new System.Drawing.Size(961, 505);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label recButtonLabel;
        private System.Windows.Forms.Label recStatusText;
        private System.Windows.Forms.Label recStatusLabel;
        private System.Windows.Forms.Label recCreatedLabel;
        private System.Windows.Forms.Label recButtonLabel2;
        private System.Windows.Forms.Button startStopRecBtn;
    }
}

namespace SequenceAutomation
{
    partial class PlayRecUserControl
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
            this.showTutorialBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.recDescLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.recTitleLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recordingsList = new System.Windows.Forms.ListBox();
            this.currentRecTitle = new System.Windows.Forms.Label();
            this.recNameLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.addFavouriteBtn = new System.Windows.Forms.Button();
            this.playRecBtn = new System.Windows.Forms.Button();
            this.favouriteBtn = new System.Windows.Forms.Button();
            this.browseBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.recSpeedLabel = new System.Windows.Forms.Label();
            this.decreaseBtn = new System.Windows.Forms.Button();
            this.increaseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchBox1 = new SequenceAutomation.SearchBox();
            this.SuspendLayout();
            // 
            // showTutorialBtn
            // 
            this.showTutorialBtn.BackColor = System.Drawing.Color.White;
            this.showTutorialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showTutorialBtn.FlatAppearance.BorderSize = 3;
            this.showTutorialBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showTutorialBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTutorialBtn.Location = new System.Drawing.Point(569, 14);
            this.showTutorialBtn.Name = "showTutorialBtn";
            this.showTutorialBtn.Size = new System.Drawing.Size(302, 52);
            this.showTutorialBtn.TabIndex = 21;
            this.showTutorialBtn.Text = "Show Tutorial";
            this.showTutorialBtn.UseVisualStyleBackColor = false;
            this.showTutorialBtn.Click += new System.EventHandler(this.showTutorial);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 41);
            this.label2.TabIndex = 30;
            this.label2.Text = "Play a recording";
            // 
            // recDescLabel
            // 
            this.recDescLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recDescLabel.Location = new System.Drawing.Point(728, 342);
            this.recDescLabel.Name = "recDescLabel";
            this.recDescLabel.Size = new System.Drawing.Size(361, 319);
            this.recDescLabel.TabIndex = 61;
            this.recDescLabel.Text = "This paragraph is an example of what would be displayed in the description of a r" +
    "ecording";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(728, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 60;
            this.label7.Text = "Description";
            // 
            // recTitleLabel
            // 
            this.recTitleLabel.AutoSize = true;
            this.recTitleLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recTitleLabel.Location = new System.Drawing.Point(728, 244);
            this.recTitleLabel.Name = "recTitleLabel";
            this.recTitleLabel.Size = new System.Drawing.Size(199, 33);
            this.recTitleLabel.TabIndex = 59;
            this.recTitleLabel.Text = "Test recording";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(728, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 32);
            this.label6.TabIndex = 58;
            this.label6.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(728, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 32);
            this.label5.TabIndex = 57;
            this.label5.Text = "Recording Info";
            // 
            // recordingsList
            // 
            this.recordingsList.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingsList.FormattingEnabled = true;
            this.recordingsList.ItemHeight = 24;
            this.recordingsList.Location = new System.Drawing.Point(418, 205);
            this.recordingsList.Name = "recordingsList";
            this.recordingsList.Size = new System.Drawing.Size(304, 340);
            this.recordingsList.TabIndex = 56;
            this.recordingsList.SelectedIndexChanged += new System.EventHandler(this.updateList);
            // 
            // currentRecTitle
            // 
            this.currentRecTitle.AutoSize = true;
            this.currentRecTitle.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRecTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentRecTitle.Location = new System.Drawing.Point(1024, 238);
            this.currentRecTitle.Name = "currentRecTitle";
            this.currentRecTitle.Size = new System.Drawing.Size(0, 42);
            this.currentRecTitle.TabIndex = 72;
            // 
            // recNameLabel
            // 
            this.recNameLabel.AutoSize = true;
            this.recNameLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.recNameLabel.Location = new System.Drawing.Point(679, 102);
            this.recNameLabel.Name = "recNameLabel";
            this.recNameLabel.Size = new System.Drawing.Size(293, 33);
            this.recNameLabel.TabIndex = 84;
            this.recNameLabel.Text = "No recording loaded";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(412, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 32);
            this.label9.TabIndex = 83;
            this.label9.Text = "Current Recording:\r\n";
            // 
            // addFavouriteBtn
            // 
            this.addFavouriteBtn.BackColor = System.Drawing.Color.Transparent;
            this.addFavouriteBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.addtofavourites;
            this.addFavouriteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addFavouriteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFavouriteBtn.FlatAppearance.BorderSize = 0;
            this.addFavouriteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.addFavouriteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.addFavouriteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addFavouriteBtn.Location = new System.Drawing.Point(209, 115);
            this.addFavouriteBtn.Name = "addFavouriteBtn";
            this.addFavouriteBtn.Size = new System.Drawing.Size(150, 129);
            this.addFavouriteBtn.TabIndex = 85;
            this.addFavouriteBtn.UseVisualStyleBackColor = false;
            this.addFavouriteBtn.MouseEnter += new System.EventHandler(this.addFavouriteBtn_MouseEnter);
            this.addFavouriteBtn.MouseLeave += new System.EventHandler(this.addFavouriteBtn_MouseLeave);
            // 
            // playRecBtn
            // 
            this.playRecBtn.BackColor = System.Drawing.Color.Transparent;
            this.playRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.play;
            this.playRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playRecBtn.FlatAppearance.BorderSize = 0;
            this.playRecBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.playRecBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.playRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playRecBtn.Location = new System.Drawing.Point(21, 102);
            this.playRecBtn.Name = "playRecBtn";
            this.playRecBtn.Size = new System.Drawing.Size(150, 150);
            this.playRecBtn.TabIndex = 70;
            this.playRecBtn.UseVisualStyleBackColor = false;
            this.playRecBtn.Click += new System.EventHandler(this.playRecording);
            this.playRecBtn.MouseEnter += new System.EventHandler(this.playRecBtn_MouseEnter);
            this.playRecBtn.MouseLeave += new System.EventHandler(this.playRecBtn_MouseLeave);
            // 
            // favouriteBtn
            // 
            this.favouriteBtn.BackColor = System.Drawing.Color.Transparent;
            this.favouriteBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.favourite;
            this.favouriteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.favouriteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.favouriteBtn.FlatAppearance.BorderSize = 0;
            this.favouriteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.favouriteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.favouriteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.favouriteBtn.Location = new System.Drawing.Point(612, 559);
            this.favouriteBtn.Name = "favouriteBtn";
            this.favouriteBtn.Size = new System.Drawing.Size(110, 110);
            this.favouriteBtn.TabIndex = 68;
            this.favouriteBtn.UseVisualStyleBackColor = false;
            this.favouriteBtn.MouseEnter += new System.EventHandler(this.favouriteBtn_MouseEnter);
            this.favouriteBtn.MouseLeave += new System.EventHandler(this.favouriteBtn_MouseLeave);
            // 
            // browseBtn
            // 
            this.browseBtn.BackColor = System.Drawing.Color.Transparent;
            this.browseBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.browse;
            this.browseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.browseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseBtn.FlatAppearance.BorderSize = 0;
            this.browseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.browseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.browseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseBtn.Location = new System.Drawing.Point(418, 567);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(131, 94);
            this.browseBtn.TabIndex = 66;
            this.browseBtn.UseVisualStyleBackColor = false;
            this.browseBtn.Click += new System.EventHandler(this.chooseFile);
            this.browseBtn.MouseEnter += new System.EventHandler(this.browseBtn_MouseEnter);
            this.browseBtn.MouseLeave += new System.EventHandler(this.browseBtn_MouseLeave);
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.home;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Location = new System.Drawing.Point(1065, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(110, 110);
            this.homeBtn.TabIndex = 63;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.gotoLogin);
            this.homeBtn.MouseEnter += new System.EventHandler(this.homeBtn_MouseEnter);
            this.homeBtn.MouseLeave += new System.EventHandler(this.homeBtn_MouseLeave);
            // 
            // goBackBtn
            // 
            this.goBackBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.backbutton;
            this.goBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackBtn.FlatAppearance.BorderSize = 0;
            this.goBackBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.goBackBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.goBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(3, 4);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 22;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // recSpeedLabel
            // 
            this.recSpeedLabel.BackColor = System.Drawing.Color.Transparent;
            this.recSpeedLabel.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recSpeedLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.recSpeedLabel.Location = new System.Drawing.Point(121, 384);
            this.recSpeedLabel.Name = "recSpeedLabel";
            this.recSpeedLabel.Size = new System.Drawing.Size(249, 37);
            this.recSpeedLabel.TabIndex = 88;
            this.recSpeedLabel.Text = " 3 - Normal";
            // 
            // decreaseBtn
            // 
            this.decreaseBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.downarrow;
            this.decreaseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.decreaseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.decreaseBtn.FlatAppearance.BorderSize = 0;
            this.decreaseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.decreaseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.decreaseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decreaseBtn.Location = new System.Drawing.Point(49, 424);
            this.decreaseBtn.Name = "decreaseBtn";
            this.decreaseBtn.Size = new System.Drawing.Size(75, 60);
            this.decreaseBtn.TabIndex = 87;
            this.decreaseBtn.UseVisualStyleBackColor = true;
            this.decreaseBtn.Click += new System.EventHandler(this.decreaseSpeed);
            this.decreaseBtn.MouseEnter += new System.EventHandler(this.decreaseBtn_MouseEnter);
            this.decreaseBtn.MouseLeave += new System.EventHandler(this.decreaseBtn_MouseLeave);
            // 
            // increaseBtn
            // 
            this.increaseBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.uparrow;
            this.increaseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.increaseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.increaseBtn.FlatAppearance.BorderSize = 0;
            this.increaseBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.increaseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.increaseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.increaseBtn.Location = new System.Drawing.Point(49, 319);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(75, 60);
            this.increaseBtn.TabIndex = 86;
            this.increaseBtn.UseVisualStyleBackColor = true;
            this.increaseBtn.Click += new System.EventHandler(this.increaseSpeed);
            this.increaseBtn.MouseEnter += new System.EventHandler(this.increaseBtn_MouseEnter);
            this.increaseBtn.MouseLeave += new System.EventHandler(this.increaseBtn_MouseLeave);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 48);
            this.label1.TabIndex = 89;
            this.label1.Text = "Speed";
            // 
            // searchBox1
            // 
            this.searchBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox1.Location = new System.Drawing.Point(418, 157);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.Size = new System.Drawing.Size(304, 33);
            this.searchBox1.TabIndex = 64;
            // 
            // PlayRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recSpeedLabel);
            this.Controls.Add(this.decreaseBtn);
            this.Controls.Add(this.increaseBtn);
            this.Controls.Add(this.addFavouriteBtn);
            this.Controls.Add(this.recNameLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.currentRecTitle);
            this.Controls.Add(this.playRecBtn);
            this.Controls.Add(this.favouriteBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.searchBox1);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.recDescLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.recTitleLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.recordingsList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.showTutorialBtn);
            this.DoubleBuffered = true;
            this.Name = "PlayRecUserControl";
            this.Size = new System.Drawing.Size(1178, 684);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showTutorialBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button favouriteBtn;
        private System.Windows.Forms.Button browseBtn;
        private SearchBox searchBox1;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label recDescLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label recTitleLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox recordingsList;
        public System.Windows.Forms.Label currentRecTitle;
        private System.Windows.Forms.Button playRecBtn;
        private System.Windows.Forms.Label recNameLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button addFavouriteBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label recSpeedLabel;
        private System.Windows.Forms.Button decreaseBtn;
        private System.Windows.Forms.Button increaseBtn;
        private System.Windows.Forms.Label label1;
    }
}

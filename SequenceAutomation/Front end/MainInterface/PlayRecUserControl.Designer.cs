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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.recAuthorLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.searchBox = new SequenceAutomation.SearchBox();
            this.SuspendLayout();
            // 
            // showTutorialBtn
            // 
            this.showTutorialBtn.BackColor = System.Drawing.Color.White;
            this.showTutorialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showTutorialBtn.FlatAppearance.BorderSize = 3;
            this.showTutorialBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showTutorialBtn.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTutorialBtn.Location = new System.Drawing.Point(569, 14);
            this.showTutorialBtn.Name = "showTutorialBtn";
            this.showTutorialBtn.Size = new System.Drawing.Size(302, 62);
            this.showTutorialBtn.TabIndex = 21;
            this.showTutorialBtn.Text = "Show Tutorial";
            this.showTutorialBtn.UseVisualStyleBackColor = false;
            this.showTutorialBtn.Click += new System.EventHandler(this.showTutorial);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(222, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 47);
            this.label2.TabIndex = 30;
            this.label2.Text = "Play a recording";
            // 
            // recDescLabel
            // 
            this.recDescLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recDescLabel.Location = new System.Drawing.Point(856, 361);
            this.recDescLabel.Name = "recDescLabel";
            this.recDescLabel.Size = new System.Drawing.Size(361, 295);
            this.recDescLabel.TabIndex = 61;
            this.recDescLabel.Text = "Unavailable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(856, 319);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 37);
            this.label7.TabIndex = 60;
            this.label7.Text = "Description";
            // 
            // recTitleLabel
            // 
            this.recTitleLabel.AutoSize = true;
            this.recTitleLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recTitleLabel.Location = new System.Drawing.Point(856, 194);
            this.recTitleLabel.Name = "recTitleLabel";
            this.recTitleLabel.Size = new System.Drawing.Size(157, 37);
            this.recTitleLabel.TabIndex = 59;
            this.recTitleLabel.Text = "Unavailable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(856, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 37);
            this.label6.TabIndex = 58;
            this.label6.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(856, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(310, 37);
            this.label5.TabIndex = 57;
            this.label5.Text = "Recording Information";
            // 
            // recordingsList
            // 
            this.recordingsList.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingsList.FormattingEnabled = true;
            this.recordingsList.ItemHeight = 30;
            this.recordingsList.Location = new System.Drawing.Point(418, 158);
            this.recordingsList.Name = "recordingsList";
            this.recordingsList.Size = new System.Drawing.Size(409, 364);
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
            this.addFavouriteBtn.Click += new System.EventHandler(this.addToFavourites);
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
            this.favouriteBtn.Location = new System.Drawing.Point(418, 554);
            this.favouriteBtn.Name = "favouriteBtn";
            this.favouriteBtn.Size = new System.Drawing.Size(110, 110);
            this.favouriteBtn.TabIndex = 68;
            this.favouriteBtn.UseVisualStyleBackColor = false;
            this.favouriteBtn.Click += new System.EventHandler(this.showFavourites);
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
            this.browseBtn.Location = new System.Drawing.Point(555, 562);
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
            this.homeBtn.Location = new System.Drawing.Point(1148, 4);
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
            this.recSpeedLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recSpeedLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.recSpeedLabel.Location = new System.Drawing.Point(130, 384);
            this.recSpeedLabel.Name = "recSpeedLabel";
            this.recSpeedLabel.Size = new System.Drawing.Size(249, 50);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(28, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 48);
            this.label1.TabIndex = 89;
            this.label1.Text = "Speed";
            // 
            // deleteBtn
            // 
            this.deleteBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.delete;
            this.deleteBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatAppearance.BorderSize = 0;
            this.deleteBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.deleteBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Location = new System.Drawing.Point(727, 544);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 120);
            this.deleteBtn.TabIndex = 90;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteRec);
            this.deleteBtn.MouseEnter += new System.EventHandler(this.deleteBtn_mouseEnter);
            this.deleteBtn.MouseLeave += new System.EventHandler(this.deleteBtn_mouseLeave);
            // 
            // recAuthorLabel
            // 
            this.recAuthorLabel.AutoSize = true;
            this.recAuthorLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recAuthorLabel.Location = new System.Drawing.Point(856, 274);
            this.recAuthorLabel.Name = "recAuthorLabel";
            this.recAuthorLabel.Size = new System.Drawing.Size(157, 37);
            this.recAuthorLabel.TabIndex = 92;
            this.recAuthorLabel.Text = "Unavailable";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(856, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 37);
            this.label4.TabIndex = 91;
            this.label4.Text = "Author";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(418, 115);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(409, 35);
            this.searchBox.TabIndex = 64;
            this.searchBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.searchListUpdate);
            // 
            // PlayRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.recAuthorLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recSpeedLabel);
            this.Controls.Add(this.decreaseBtn);
            this.Controls.Add(this.increaseBtn);
            this.Controls.Add(this.addFavouriteBtn);
            this.Controls.Add(this.currentRecTitle);
            this.Controls.Add(this.playRecBtn);
            this.Controls.Add(this.favouriteBtn);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.searchBox);
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
            this.Size = new System.Drawing.Size(1270, 680);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button showTutorialBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button favouriteBtn;
        private System.Windows.Forms.Button browseBtn;
        private SearchBox searchBox;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label recDescLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label recTitleLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox recordingsList;
        public System.Windows.Forms.Label currentRecTitle;
        private System.Windows.Forms.Button playRecBtn;
        private System.Windows.Forms.Button addFavouriteBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label recSpeedLabel;
        private System.Windows.Forms.Button decreaseBtn;
        private System.Windows.Forms.Button increaseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label recAuthorLabel;
        private System.Windows.Forms.Label label4;
    }
}

namespace SequenceAutomation
{
    partial class FavouritesBox
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
            this.recDescLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.recTitleLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recordingsList = new System.Windows.Forms.ListBox();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.searchBox = new SequenceAutomation.SearchBox();
            this.doneBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recDescLabel
            // 
            this.recDescLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recDescLabel.Location = new System.Drawing.Point(326, 239);
            this.recDescLabel.Name = "recDescLabel";
            this.recDescLabel.Size = new System.Drawing.Size(411, 252);
            this.recDescLabel.TabIndex = 70;
            this.recDescLabel.Text = "Unavailable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(326, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 69;
            this.label7.Text = "Description";
            // 
            // recTitleLabel
            // 
            this.recTitleLabel.AutoSize = true;
            this.recTitleLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recTitleLabel.Location = new System.Drawing.Point(326, 141);
            this.recTitleLabel.Name = "recTitleLabel";
            this.recTitleLabel.Size = new System.Drawing.Size(173, 33);
            this.recTitleLabel.TabIndex = 68;
            this.recTitleLabel.Text = "Unavailable";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(326, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 32);
            this.label6.TabIndex = 67;
            this.label6.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(326, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 32);
            this.label5.TabIndex = 66;
            this.label5.Text = "Recording Info";
            // 
            // recordingsList
            // 
            this.recordingsList.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingsList.FormattingEnabled = true;
            this.recordingsList.ItemHeight = 24;
            this.recordingsList.Location = new System.Drawing.Point(16, 103);
            this.recordingsList.Name = "recordingsList";
            this.recordingsList.Size = new System.Drawing.Size(304, 532);
            this.recordingsList.TabIndex = 65;
            this.recordingsList.SelectedIndexChanged += new System.EventHandler(this.updateInfo);
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
            this.deleteBtn.Location = new System.Drawing.Point(432, 515);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(100, 120);
            this.deleteBtn.TabIndex = 73;
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteFavourite);
            this.deleteBtn.MouseEnter += new System.EventHandler(this.deleteBtn_MouseEnter);
            this.deleteBtn.MouseLeave += new System.EventHandler(this.deleteBtn_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(439, 41);
            this.label2.TabIndex = 74;
            this.label2.Text = "Your favourite recordings";
            // 
            // searchBox
            // 
            this.searchBox.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBox.Location = new System.Drawing.Point(16, 60);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(304, 33);
            this.searchBox.TabIndex = 71;
            // 
            // doneBtn
            // 
            this.doneBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.done;
            this.doneBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doneBtn.FlatAppearance.BorderSize = 0;
            this.doneBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.doneBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneBtn.Location = new System.Drawing.Point(602, 515);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(144, 120);
            this.doneBtn.TabIndex = 72;
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneSelecting);
            this.doneBtn.MouseEnter += new System.EventHandler(this.doneBtn_MouseEnter);
            this.doneBtn.MouseLeave += new System.EventHandler(this.doneBtn_MouseLeave);
            // 
            // FavouritesBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(745, 643);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.recDescLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.recTitleLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.recordingsList);
            this.Name = "FavouritesBox";
            this.Text = "Your favourites";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SearchBox searchBox;
        private System.Windows.Forms.Label recDescLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label recTitleLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox recordingsList;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button doneBtn;
    }
}
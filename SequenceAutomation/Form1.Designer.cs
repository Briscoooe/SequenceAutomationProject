namespace SequenceAutomation
{
    partial class Form1
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
            this.RecListTB = new System.Windows.Forms.ListView();
            this.RecInfoLabel = new System.Windows.Forms.Label();
            this.UploadBtn = new System.Windows.Forms.Button();
            this.DownloadBtn = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.SaveRecBtn = new System.Windows.Forms.Button();
            this.CreateRecBtn = new System.Windows.Forms.Button();
            this.PlayRecBtn = new System.Windows.Forms.Button();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.RecInfoTB = new System.Windows.Forms.TextBox();
            this.CurrentRecTB = new System.Windows.Forms.TextBox();
            this.OpenRecDialog = new System.Windows.Forms.OpenFileDialog();
            this.CurrentRecLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RecListTB
            // 
            this.RecListTB.Location = new System.Drawing.Point(228, 35);
            this.RecListTB.Name = "RecListTB";
            this.RecListTB.Size = new System.Drawing.Size(162, 181);
            this.RecListTB.TabIndex = 0;
            this.RecListTB.UseCompatibleStateImageBehavior = false;
            // 
            // RecInfoLabel
            // 
            this.RecInfoLabel.AutoSize = true;
            this.RecInfoLabel.Location = new System.Drawing.Point(395, 13);
            this.RecInfoLabel.Name = "RecInfoLabel";
            this.RecInfoLabel.Size = new System.Drawing.Size(79, 13);
            this.RecInfoLabel.TabIndex = 1;
            this.RecInfoLabel.Text = "Recording Title";
            // 
            // UploadBtn
            // 
            this.UploadBtn.Location = new System.Drawing.Point(228, 223);
            this.UploadBtn.Name = "UploadBtn";
            this.UploadBtn.Size = new System.Drawing.Size(75, 23);
            this.UploadBtn.TabIndex = 2;
            this.UploadBtn.Text = "Upload";
            this.UploadBtn.UseVisualStyleBackColor = true;
            this.UploadBtn.Click += new System.EventHandler(this.UploadBtn_Click);
            // 
            // DownloadBtn
            // 
            this.DownloadBtn.Location = new System.Drawing.Point(314, 222);
            this.DownloadBtn.Name = "DownloadBtn";
            this.DownloadBtn.Size = new System.Drawing.Size(75, 23);
            this.DownloadBtn.TabIndex = 3;
            this.DownloadBtn.Text = "Download";
            this.DownloadBtn.UseVisualStyleBackColor = true;
            this.DownloadBtn.Click += new System.EventHandler(this.DownloadBtn_Click);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(123, 223);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(75, 23);
            this.BrowseBtn.TabIndex = 4;
            this.BrowseBtn.Text = "Browse..";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
            // 
            // SaveRecBtn
            // 
            this.SaveRecBtn.Location = new System.Drawing.Point(42, 223);
            this.SaveRecBtn.Name = "SaveRecBtn";
            this.SaveRecBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveRecBtn.TabIndex = 5;
            this.SaveRecBtn.Text = "Save";
            this.SaveRecBtn.UseVisualStyleBackColor = true;
            // 
            // CreateRecBtn
            // 
            this.CreateRecBtn.Location = new System.Drawing.Point(26, 35);
            this.CreateRecBtn.Name = "CreateRecBtn";
            this.CreateRecBtn.Size = new System.Drawing.Size(122, 23);
            this.CreateRecBtn.TabIndex = 6;
            this.CreateRecBtn.Text = "Create Recording";
            this.CreateRecBtn.UseVisualStyleBackColor = true;
            // 
            // PlayRecBtn
            // 
            this.PlayRecBtn.Location = new System.Drawing.Point(26, 86);
            this.PlayRecBtn.Name = "PlayRecBtn";
            this.PlayRecBtn.Size = new System.Drawing.Size(122, 23);
            this.PlayRecBtn.TabIndex = 7;
            this.PlayRecBtn.Text = "Play Recording";
            this.PlayRecBtn.UseVisualStyleBackColor = true;
            // 
            // SearchTB
            // 
            this.SearchTB.Location = new System.Drawing.Point(228, 13);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(161, 20);
            this.SearchTB.TabIndex = 8;
            this.SearchTB.Text = "Search...";
            // 
            // RecInfoTB
            // 
            this.RecInfoTB.Location = new System.Drawing.Point(398, 35);
            this.RecInfoTB.Multiline = true;
            this.RecInfoTB.Name = "RecInfoTB";
            this.RecInfoTB.Size = new System.Drawing.Size(142, 181);
            this.RecInfoTB.TabIndex = 9;
            this.RecInfoTB.Text = "Recording Author\r\nRecording Data\r\nRecording Info Line1...\r\nLine2....\r\nLine3...\r\n." +
    "..\r\nLine N\r\n";
            // 
            // CurrentRecTB
            // 
            this.CurrentRecTB.Location = new System.Drawing.Point(26, 195);
            this.CurrentRecTB.Name = "CurrentRecTB";
            this.CurrentRecTB.Size = new System.Drawing.Size(172, 20);
            this.CurrentRecTB.TabIndex = 10;
            // 
            // OpenRecDialog
            // 
            this.OpenRecDialog.FileName = "recording.xml";
            // 
            // CurrentRecLabel
            // 
            this.CurrentRecLabel.AutoSize = true;
            this.CurrentRecLabel.Location = new System.Drawing.Point(26, 176);
            this.CurrentRecLabel.Name = "CurrentRecLabel";
            this.CurrentRecLabel.Size = new System.Drawing.Size(93, 13);
            this.CurrentRecLabel.TabIndex = 11;
            this.CurrentRecLabel.Text = "Current Recording";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 261);
            this.Controls.Add(this.CurrentRecLabel);
            this.Controls.Add(this.CurrentRecTB);
            this.Controls.Add(this.RecInfoTB);
            this.Controls.Add(this.SearchTB);
            this.Controls.Add(this.PlayRecBtn);
            this.Controls.Add(this.CreateRecBtn);
            this.Controls.Add(this.SaveRecBtn);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.DownloadBtn);
            this.Controls.Add(this.UploadBtn);
            this.Controls.Add(this.RecInfoLabel);
            this.Controls.Add(this.RecListTB);
            this.Name = "Form1";
            this.Text = "Sequence Automator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView RecListTB;
        private System.Windows.Forms.Label RecInfoLabel;
        private System.Windows.Forms.Button UploadBtn;
        private System.Windows.Forms.Button DownloadBtn;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.Button SaveRecBtn;
        private System.Windows.Forms.Button CreateRecBtn;
        private System.Windows.Forms.Button PlayRecBtn;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.TextBox RecInfoTB;
        private System.Windows.Forms.TextBox CurrentRecTB;
        private System.Windows.Forms.OpenFileDialog OpenRecDialog;
        private System.Windows.Forms.Label CurrentRecLabel;
    }
}


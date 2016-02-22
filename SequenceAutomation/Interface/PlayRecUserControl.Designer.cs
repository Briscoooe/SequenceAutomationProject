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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayRecUserControl));
            this.playRecBtn = new System.Windows.Forms.Button();
            this.recordingsList = new System.Windows.Forms.ListBox();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playRecBtn
            // 
            this.playRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playRecBtn.Location = new System.Drawing.Point(45, 126);
            this.playRecBtn.Name = "playRecBtn";
            this.playRecBtn.Size = new System.Drawing.Size(206, 178);
            this.playRecBtn.TabIndex = 0;
            this.playRecBtn.Text = "Play Recording";
            this.playRecBtn.UseVisualStyleBackColor = true;
            // 
            // recordingsList
            // 
            this.recordingsList.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingsList.FormattingEnabled = true;
            this.recordingsList.ItemHeight = 36;
            this.recordingsList.Location = new System.Drawing.Point(495, 39);
            this.recordingsList.Name = "recordingsList";
            this.recordingsList.Size = new System.Drawing.Size(442, 364);
            this.recordingsList.TabIndex = 1;
            // 
            // goBackBtn
            // 
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(45, 39);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(206, 48);
            this.goBackBtn.TabIndex = 2;
            this.goBackBtn.Text = "Go back";
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += goBack;
            // 
            // loadBtn
            // 
            this.loadBtn.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBtn.Location = new System.Drawing.Point(495, 421);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(442, 50);
            this.loadBtn.TabIndex = 3;
            this.loadBtn.Text = "Load for playback";
            this.loadBtn.UseVisualStyleBackColor = true;
            // 
            // PlayRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.recordingsList);
            this.Controls.Add(this.playRecBtn);
            this.Name = "PlayRecUserControl";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playRecBtn;
        private System.Windows.Forms.ListBox recordingsList;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}

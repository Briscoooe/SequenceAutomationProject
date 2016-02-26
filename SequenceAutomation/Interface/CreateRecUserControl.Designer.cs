using System;

namespace SequenceAutomation
{
    partial class CreateRecUserControl
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
            this.testRecBtn = new System.Windows.Forms.Button();
            this.recStatusLabel = new System.Windows.Forms.Label();
            this.recStatusText = new System.Windows.Forms.Label();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.uploadTb = new System.Windows.Forms.TextBox();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.startStopRecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testRecBtn
            // 
            this.testRecBtn.BackColor = System.Drawing.Color.White;
            this.testRecBtn.FlatAppearance.BorderSize = 3;
            this.testRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testRecBtn.Location = new System.Drawing.Point(47, 347);
            this.testRecBtn.Name = "testRecBtn";
            this.testRecBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.testRecBtn.Size = new System.Drawing.Size(213, 131);
            this.testRecBtn.TabIndex = 1;
            this.testRecBtn.Text = "Test Recording";
            this.testRecBtn.UseVisualStyleBackColor = false;
            this.testRecBtn.Click += new System.EventHandler(this.testRecording);
            // 
            // recStatusLabel
            // 
            this.recStatusLabel.AutoSize = true;
            this.recStatusLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recStatusLabel.Location = new System.Drawing.Point(311, 25);
            this.recStatusLabel.Name = "recStatusLabel";
            this.recStatusLabel.Size = new System.Drawing.Size(241, 32);
            this.recStatusLabel.TabIndex = 3;
            this.recStatusLabel.Text = "Recording Status:";
            // 
            // recStatusText
            // 
            this.recStatusText.AutoSize = true;
            this.recStatusText.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recStatusText.ForeColor = System.Drawing.Color.Red;
            this.recStatusText.Location = new System.Drawing.Point(558, 25);
            this.recStatusText.Name = "recStatusText";
            this.recStatusText.Size = new System.Drawing.Size(195, 32);
            this.recStatusText.TabIndex = 4;
            this.recStatusText.Text = "Not recording";
            // 
            // uploadBtn
            // 
            this.uploadBtn.FlatAppearance.BorderSize = 3;
            this.uploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadBtn.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadBtn.Location = new System.Drawing.Point(771, 442);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(139, 46);
            this.uploadBtn.TabIndex = 5;
            this.uploadBtn.Text = "Upload";
            this.uploadBtn.UseVisualStyleBackColor = true;
            this.uploadBtn.Click += new System.EventHandler(this.upload);
            // 
            // uploadTb
            // 
            this.uploadTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadTb.Location = new System.Drawing.Point(564, 403);
            this.uploadTb.Name = "uploadTb";
            this.uploadTb.Size = new System.Drawing.Size(346, 33);
            this.uploadTb.TabIndex = 6;
            // 
            // goBackBtn
            // 
            this.goBackBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.backbutton;
            this.goBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackBtn.FlatAppearance.BorderSize = 0;
            this.goBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(3, 6);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 2;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            // 
            // startStopRecBtn
            // 
            this.startStopRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.play4;
            this.startStopRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startStopRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startStopRecBtn.FlatAppearance.BorderSize = 0;
            this.startStopRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startStopRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopRecBtn.Location = new System.Drawing.Point(47, 102);
            this.startStopRecBtn.Name = "startStopRecBtn";
            this.startStopRecBtn.Size = new System.Drawing.Size(200, 200);
            this.startStopRecBtn.TabIndex = 0;
            this.startStopRecBtn.UseVisualStyleBackColor = true;
            this.startStopRecBtn.Click += new System.EventHandler(this.startRecording);
            // 
            // CreateRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.uploadTb);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.recStatusText);
            this.Controls.Add(this.recStatusLabel);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.testRecBtn);
            this.Controls.Add(this.startStopRecBtn);
            this.Name = "CreateRecUserControl";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startStopRecBtn;
        private System.Windows.Forms.Button testRecBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Label recStatusLabel;
        private System.Windows.Forms.Label recStatusText;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.TextBox uploadTb;
    }
}

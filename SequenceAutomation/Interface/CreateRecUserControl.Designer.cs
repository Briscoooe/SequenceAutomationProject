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
            this.startStopRecBtn = new System.Windows.Forms.Button();
            this.testRecBtn = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.recStatusLabel = new System.Windows.Forms.Label();
            this.recStatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startStopRecBtn
            // 
            this.startStopRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopRecBtn.Location = new System.Drawing.Point(47, 93);
            this.startStopRecBtn.Name = "startStopRecBtn";
            this.startStopRecBtn.Size = new System.Drawing.Size(213, 162);
            this.startStopRecBtn.TabIndex = 0;
            this.startStopRecBtn.Text = "Begin Recording";
            this.startStopRecBtn.UseVisualStyleBackColor = true;
            this.startStopRecBtn.Click += new System.EventHandler(this.startRecording);
            // 
            // testRecBtn
            // 
            this.testRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testRecBtn.Location = new System.Drawing.Point(47, 301);
            this.testRecBtn.Name = "testRecBtn";
            this.testRecBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.testRecBtn.Size = new System.Drawing.Size(213, 161);
            this.testRecBtn.TabIndex = 1;
            this.testRecBtn.Text = "Test Recording";
            this.testRecBtn.UseVisualStyleBackColor = true;
            this.testRecBtn.Click += new System.EventHandler(this.testRecording);
            // 
            // goBackBtn
            // 
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(47, 12);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(213, 51);
            this.goBackBtn.TabIndex = 2;
            this.goBackBtn.Text = "Go back";
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
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
            // CreateRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}

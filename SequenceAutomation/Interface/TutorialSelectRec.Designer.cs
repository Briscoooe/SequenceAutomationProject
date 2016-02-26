using System;

namespace SequenceAutomation
{
    partial class TutorialSelectRec
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
            this.recDescLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.recTitleLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.recordingsList = new System.Windows.Forms.ListBox();
            this.nextBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // recDescLabel
            // 
            this.recDescLabel.AutoSize = true;
            this.recDescLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recDescLabel.Location = new System.Drawing.Point(442, 286);
            this.recDescLabel.Name = "recDescLabel";
            this.recDescLabel.Size = new System.Drawing.Size(212, 33);
            this.recDescLabel.TabIndex = 24;
            this.recDescLabel.Text = "rec Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(442, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 32);
            this.label7.TabIndex = 23;
            this.label7.Text = "Description";
            // 
            // recTitleLabel
            // 
            this.recTitleLabel.AutoSize = true;
            this.recTitleLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recTitleLabel.Location = new System.Drawing.Point(442, 191);
            this.recTitleLabel.Name = "recTitleLabel";
            this.recTitleLabel.Size = new System.Drawing.Size(113, 33);
            this.recTitleLabel.TabIndex = 22;
            this.recTitleLabel.Text = "rec info";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(442, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 32);
            this.label6.TabIndex = 21;
            this.label6.Text = "Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(439, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(206, 32);
            this.label5.TabIndex = 20;
            this.label5.Text = "Recording Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 41);
            this.label4.TabIndex = 19;
            this.label4.Text = "Step 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(425, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 41);
            this.label2.TabIndex = 18;
            this.label2.Text = "Choose a recording";
            // 
            // goBackBtn
            // 
            this.goBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(26, 12);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(206, 48);
            this.goBackBtn.TabIndex = 17;
            this.goBackBtn.Text = "Go back";
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            // 
            // recordingsList
            // 
            this.recordingsList.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordingsList.FormattingEnabled = true;
            this.recordingsList.ItemHeight = 36;
            this.recordingsList.Location = new System.Drawing.Point(26, 105);
            this.recordingsList.Name = "recordingsList";
            this.recordingsList.Size = new System.Drawing.Size(407, 364);
            this.recordingsList.TabIndex = 16;
            // 
            // nextBtn
            // 
            this.nextBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextBtn.Location = new System.Drawing.Point(843, 426);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(123, 43);
            this.nextBtn.TabIndex = 25;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.goNext);
            // 
            // TutorialSelectRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.recDescLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.recTitleLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.recordingsList);
            this.Name = "TutorialSelectRec";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recDescLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label recTitleLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.ListBox recordingsList;
        private System.Windows.Forms.Button nextBtn;
    }
}

using System;

namespace SequenceAutomation
{
    partial class TutorialPlayRec
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
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.currentRecTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.Button();
            this.doneBtn = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.playRecBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(373, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(325, 41);
            this.label12.TabIndex = 26;
            this.label12.Text = "Play the recording";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(235, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 41);
            this.label11.TabIndex = 25;
            this.label11.Text = "Step 3";
            // 
            // currentRecTitle
            // 
            this.currentRecTitle.AutoSize = true;
            this.currentRecTitle.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRecTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentRecTitle.Location = new System.Drawing.Point(373, 117);
            this.currentRecTitle.Name = "currentRecTitle";
            this.currentRecTitle.Size = new System.Drawing.Size(268, 42);
            this.currentRecTitle.TabIndex = 23;
            this.currentRecTitle.Text = "Recording Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(30, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(323, 41);
            this.label1.TabIndex = 22;
            this.label1.Text = "Current Recording\r\n";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 210);
            this.label2.TabIndex = 29;
            this.label2.Text = "Now just press the play button!";
            // 
            // homeBtn
            // 
            this.homeBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.home;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Location = new System.Drawing.Point(734, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(110, 110);
            this.homeBtn.TabIndex = 30;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.gotoLogin);
            // 
            // doneBtn
            // 
            this.doneBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.done;
            this.doneBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.doneBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.doneBtn.FlatAppearance.BorderSize = 0;
            this.doneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.doneBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneBtn.Location = new System.Drawing.Point(674, 340);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(170, 125);
            this.doneBtn.TabIndex = 28;
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.gotoPlay);
            // 
            // goBackBtn
            // 
            this.goBackBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.backbutton;
            this.goBackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.goBackBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goBackBtn.FlatAppearance.BorderSize = 0;
            this.goBackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goBackBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goBackBtn.Location = new System.Drawing.Point(3, 3);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 27;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            // 
            // playRecBtn
            // 
            this.playRecBtn.BackColor = System.Drawing.Color.Transparent;
            this.playRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.play4;
            this.playRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playRecBtn.FlatAppearance.BorderSize = 0;
            this.playRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playRecBtn.Location = new System.Drawing.Point(380, 180);
            this.playRecBtn.Name = "playRecBtn";
            this.playRecBtn.Size = new System.Drawing.Size(230, 230);
            this.playRecBtn.TabIndex = 21;
            this.playRecBtn.UseVisualStyleBackColor = false;
            // 
            // TutorialPlayRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.currentRecTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playRecBtn);
            this.Name = "TutorialPlayRec";
            this.Size = new System.Drawing.Size(847, 468);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label currentRecTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button playRecBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button homeBtn;
    }
}

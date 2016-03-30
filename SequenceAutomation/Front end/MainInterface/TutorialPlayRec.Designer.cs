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
            this.increaseBtn = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.doneBtn = new System.Windows.Forms.Button();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.playRecBtn = new System.Windows.Forms.Button();
            this.decreaseBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.recSpeedLabel = new System.Windows.Forms.Label();
            this.addFavouriteBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(373, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(324, 47);
            this.label12.TabIndex = 26;
            this.label12.Text = "Play the recording";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(235, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 47);
            this.label11.TabIndex = 25;
            this.label11.Text = "Step 2:";
            // 
            // currentRecTitle
            // 
            this.currentRecTitle.AutoSize = true;
            this.currentRecTitle.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRecTitle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.currentRecTitle.Location = new System.Drawing.Point(369, 91);
            this.currentRecTitle.Name = "currentRecTitle";
            this.currentRecTitle.Size = new System.Drawing.Size(0, 42);
            this.currentRecTitle.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(21, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 47);
            this.label1.TabIndex = 22;
            this.label1.Text = "Current Recording:\r\n";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 96);
            this.label2.TabIndex = 29;
            this.label2.Text = "Now just press the play button!";
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
            this.increaseBtn.Location = new System.Drawing.Point(235, 419);
            this.increaseBtn.Name = "increaseBtn";
            this.increaseBtn.Size = new System.Drawing.Size(75, 60);
            this.increaseBtn.TabIndex = 31;
            this.increaseBtn.UseVisualStyleBackColor = true;
            this.increaseBtn.Click += new System.EventHandler(this.increaseSpeed);
            this.increaseBtn.MouseEnter += new System.EventHandler(this.increaseBtn_MouseEnter);
            this.increaseBtn.MouseLeave += new System.EventHandler(this.increaseBtn_MouseLeave);
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
            this.homeBtn.Location = new System.Drawing.Point(877, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(110, 110);
            this.homeBtn.TabIndex = 30;
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.gotoLogin);
            this.homeBtn.MouseEnter += new System.EventHandler(this.homeBtn_MouseEnter);
            this.homeBtn.MouseLeave += new System.EventHandler(this.homeBtn_MouseLeave);
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
            this.doneBtn.Location = new System.Drawing.Point(825, 562);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(144, 120);
            this.doneBtn.TabIndex = 28;
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.gotoPlay);
            this.doneBtn.MouseEnter += new System.EventHandler(this.doneBtn_MouseEnter);
            this.doneBtn.MouseLeave += new System.EventHandler(this.doneBtn_MouseLeave);
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
            this.goBackBtn.Location = new System.Drawing.Point(3, 3);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 27;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
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
            this.playRecBtn.Location = new System.Drawing.Point(346, 155);
            this.playRecBtn.Name = "playRecBtn";
            this.playRecBtn.Size = new System.Drawing.Size(150, 150);
            this.playRecBtn.TabIndex = 21;
            this.playRecBtn.UseVisualStyleBackColor = false;
            this.playRecBtn.Click += new System.EventHandler(this.testRecording);
            this.playRecBtn.MouseEnter += new System.EventHandler(this.playRecBtn_MouseEnter);
            this.playRecBtn.MouseLeave += new System.EventHandler(this.playRecBtn_MouseLeave);
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
            this.decreaseBtn.Location = new System.Drawing.Point(235, 524);
            this.decreaseBtn.Name = "decreaseBtn";
            this.decreaseBtn.Size = new System.Drawing.Size(75, 60);
            this.decreaseBtn.TabIndex = 33;
            this.decreaseBtn.UseVisualStyleBackColor = true;
            this.decreaseBtn.Click += new System.EventHandler(this.decreaseSpeed);
            this.decreaseBtn.MouseEnter += new System.EventHandler(this.decreaseBtn_MouseEnter);
            this.decreaseBtn.MouseLeave += new System.EventHandler(this.decreaseBtn_MouseLeave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(24, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(501, 82);
            this.label3.TabIndex = 34;
            this.label3.Text = "Didn\'t work correctly? Try decreasing the speed";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 434);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 45);
            this.label4.TabIndex = 35;
            this.label4.Text = "Speed up";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 45);
            this.label5.TabIndex = 36;
            this.label5.Text = "Slow down";
            // 
            // recSpeedLabel
            // 
            this.recSpeedLabel.BackColor = System.Drawing.Color.Transparent;
            this.recSpeedLabel.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recSpeedLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.recSpeedLabel.Location = new System.Drawing.Point(307, 482);
            this.recSpeedLabel.Name = "recSpeedLabel";
            this.recSpeedLabel.Size = new System.Drawing.Size(249, 39);
            this.recSpeedLabel.TabIndex = 37;
            this.recSpeedLabel.Text = " 3 - Normal";
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
            this.addFavouriteBtn.Location = new System.Drawing.Point(819, 308);
            this.addFavouriteBtn.Name = "addFavouriteBtn";
            this.addFavouriteBtn.Size = new System.Drawing.Size(150, 129);
            this.addFavouriteBtn.TabIndex = 86;
            this.addFavouriteBtn.UseVisualStyleBackColor = false;
            this.addFavouriteBtn.Click += new System.EventHandler(this.addToFavourites);
            this.addFavouriteBtn.MouseEnter += new System.EventHandler(this.addFavouriteBtn_MouseEnter);
            this.addFavouriteBtn.MouseLeave += new System.EventHandler(this.addFavouriteBtn_MouseLeave);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(549, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(456, 150);
            this.label6.TabIndex = 87;
            this.label6.Text = "If you wish to save this recording for later use, save it to your favourites";
            // 
            // TutorialPlayRec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addFavouriteBtn);
            this.Controls.Add(this.recSpeedLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.decreaseBtn);
            this.Controls.Add(this.increaseBtn);
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
            this.Size = new System.Drawing.Size(1000, 697);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label currentRecTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button playRecBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button doneBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button increaseBtn;
        private System.Windows.Forms.Button decreaseBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label recSpeedLabel;
        private System.Windows.Forms.Button addFavouriteBtn;
        private System.Windows.Forms.Label label6;
    }
}

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
            this.goBackBtn = new System.Windows.Forms.Button();
            this.startStopRecBtn = new System.Windows.Forms.Button();
            this.recButtonLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.Button();
            this.favouriteBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.uploadBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.recTitleTb = new System.Windows.Forms.RichTextBox();
            this.recDescTb = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.showTutorialBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testRecBtn
            // 
            this.testRecBtn.BackColor = System.Drawing.Color.Transparent;
            this.testRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.play;
            this.testRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.testRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testRecBtn.FlatAppearance.BorderSize = 0;
            this.testRecBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.testRecBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.testRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testRecBtn.Location = new System.Drawing.Point(80, 397);
            this.testRecBtn.Name = "testRecBtn";
            this.testRecBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.testRecBtn.Size = new System.Drawing.Size(150, 150);
            this.testRecBtn.TabIndex = 3;
            this.testRecBtn.UseVisualStyleBackColor = false;
            this.testRecBtn.Click += new System.EventHandler(this.testRecording);
            this.testRecBtn.MouseEnter += new System.EventHandler(this.testRecBtn_MouseEnter);
            this.testRecBtn.MouseLeave += new System.EventHandler(this.testRecBtn_MouseLeave);
            // 
            // recStatusLabel
            // 
            this.recStatusLabel.AutoSize = true;
            this.recStatusLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recStatusLabel.Location = new System.Drawing.Point(343, 81);
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
            this.recStatusText.Location = new System.Drawing.Point(590, 81);
            this.recStatusText.Name = "recStatusText";
            this.recStatusText.Size = new System.Drawing.Size(195, 32);
            this.recStatusText.TabIndex = 4;
            this.recStatusText.Text = "Not recording";
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
            this.goBackBtn.TabIndex = 1;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
            // 
            // startStopRecBtn
            // 
            this.startStopRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.record;
            this.startStopRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startStopRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startStopRecBtn.FlatAppearance.BorderSize = 0;
            this.startStopRecBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startStopRecBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startStopRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startStopRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startStopRecBtn.Location = new System.Drawing.Point(80, 162);
            this.startStopRecBtn.Name = "startStopRecBtn";
            this.startStopRecBtn.Size = new System.Drawing.Size(150, 150);
            this.startStopRecBtn.TabIndex = 2;
            this.startStopRecBtn.Tag = "startRecTag";
            this.startStopRecBtn.UseVisualStyleBackColor = true;
            this.startStopRecBtn.Click += new System.EventHandler(this.startRecording);
            this.startStopRecBtn.MouseEnter += new System.EventHandler(this.startStopRecBtn_MouseEnter);
            this.startStopRecBtn.MouseLeave += new System.EventHandler(this.startStopRecBtn_MouseLeave);
            // 
            // recButtonLabel
            // 
            this.recButtonLabel.AutoSize = true;
            this.recButtonLabel.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recButtonLabel.Location = new System.Drawing.Point(50, 116);
            this.recButtonLabel.Name = "recButtonLabel";
            this.recButtonLabel.Size = new System.Drawing.Size(223, 32);
            this.recButtonLabel.TabIndex = 7;
            this.recButtonLabel.Text = "Begin recording";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "Play recording";
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Transparent;
            this.homeBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.home;
            this.homeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.FlatAppearance.BorderSize = 0;
            this.homeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.homeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homeBtn.Location = new System.Drawing.Point(1095, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(110, 110);
            this.homeBtn.TabIndex = 10;
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.goBack);
            this.homeBtn.MouseEnter += new System.EventHandler(this.homeBtn_MouseEnter);
            this.homeBtn.MouseLeave += new System.EventHandler(this.homeBtn_MouseLeave);
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
            this.favouriteBtn.Location = new System.Drawing.Point(995, 397);
            this.favouriteBtn.Name = "favouriteBtn";
            this.favouriteBtn.Size = new System.Drawing.Size(110, 110);
            this.favouriteBtn.TabIndex = 9;
            this.favouriteBtn.UseVisualStyleBackColor = false;
            this.favouriteBtn.MouseEnter += new System.EventHandler(this.favouriteBtn_MouseEnter);
            this.favouriteBtn.MouseLeave += new System.EventHandler(this.favouriteBtn_MouseLeave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(719, 431);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 33);
            this.label7.TabIndex = 58;
            this.label7.Text = "Add to favourites";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(719, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(232, 33);
            this.label6.TabIndex = 57;
            this.label6.Text = "Upload to server";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(719, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 33);
            this.label5.TabIndex = 56;
            this.label5.Text = "Save to computer";
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.save;
            this.saveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.saveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Location = new System.Drawing.Point(995, 265);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 100);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveFile);
            this.saveBtn.MouseEnter += new System.EventHandler(this.saveBtn_MouseEnter);
            this.saveBtn.MouseLeave += new System.EventHandler(this.saveBtn_MouseLeave);
            // 
            // uploadBtn
            // 
            this.uploadBtn.BackColor = System.Drawing.Color.Transparent;
            this.uploadBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.upload;
            this.uploadBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uploadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uploadBtn.FlatAppearance.BorderSize = 0;
            this.uploadBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.uploadBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.uploadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadBtn.Location = new System.Drawing.Point(985, 137);
            this.uploadBtn.Name = "uploadBtn";
            this.uploadBtn.Size = new System.Drawing.Size(120, 79);
            this.uploadBtn.TabIndex = 7;
            this.uploadBtn.UseVisualStyleBackColor = false;
            this.uploadBtn.Click += new System.EventHandler(this.uploadRecording);
            this.uploadBtn.MouseEnter += new System.EventHandler(this.uploadBtn_MouseEnter);
            this.uploadBtn.MouseLeave += new System.EventHandler(this.uploadBtn_MouseLeave);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(345, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 78);
            this.label3.TabIndex = 63;
            this.label3.Text = "Recording description (optional)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(345, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 33);
            this.label2.TabIndex = 62;
            this.label2.Text = "Recording title";
            // 
            // recTitleTb
            // 
            this.recTitleTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recTitleTb.Location = new System.Drawing.Point(351, 153);
            this.recTitleTb.Name = "recTitleTb";
            this.recTitleTb.Size = new System.Drawing.Size(300, 31);
            this.recTitleTb.TabIndex = 4;
            this.recTitleTb.Text = "";
            // 
            // recDescTb
            // 
            this.recDescTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recDescTb.Location = new System.Drawing.Point(351, 277);
            this.recDescTb.Name = "recDescTb";
            this.recDescTb.Size = new System.Drawing.Size(300, 288);
            this.recDescTb.TabIndex = 5;
            this.recDescTb.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(289, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(339, 41);
            this.label4.TabIndex = 65;
            this.label4.Text = "Create a recording";
            // 
            // showTutorialBtn
            // 
            this.showTutorialBtn.BackColor = System.Drawing.Color.White;
            this.showTutorialBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showTutorialBtn.FlatAppearance.BorderSize = 3;
            this.showTutorialBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showTutorialBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showTutorialBtn.Location = new System.Drawing.Point(671, 19);
            this.showTutorialBtn.Name = "showTutorialBtn";
            this.showTutorialBtn.Size = new System.Drawing.Size(302, 52);
            this.showTutorialBtn.TabIndex = 66;
            this.showTutorialBtn.Text = "Show Tutorial";
            this.showTutorialBtn.UseVisualStyleBackColor = false;
            this.showTutorialBtn.Click += new System.EventHandler(this.showTutorial);
            // 
            // CreateRecUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.showTutorialBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recTitleTb);
            this.Controls.Add(this.recDescTb);
            this.Controls.Add(this.favouriteBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.uploadBtn);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.recButtonLabel);
            this.Controls.Add(this.recStatusText);
            this.Controls.Add(this.recStatusLabel);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.testRecBtn);
            this.Controls.Add(this.startStopRecBtn);
            this.Name = "CreateRecUserControl";
            this.Size = new System.Drawing.Size(1208, 612);
            this.Tag = "startRecTag";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button testRecBtn;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Label recStatusLabel;
        private System.Windows.Forms.Label recStatusText;
        private System.Windows.Forms.Button startStopRecBtn;
        private System.Windows.Forms.Label recButtonLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Button favouriteBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button uploadBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox recTitleTb;
        private System.Windows.Forms.RichTextBox recDescTb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showTutorialBtn;
    }
}

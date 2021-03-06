﻿namespace SequenceAutomation.Interface
{
    partial class FirstTimeCreate
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rememberChoiceBtn = new System.Windows.Forms.CheckBox();
            this.noBtn = new System.Windows.Forms.Button();
            this.yesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(702, 47);
            this.label2.TabIndex = 9;
            this.label2.Text = "\"Yes\" is recommended for first time users";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(102, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 145);
            this.label1.TabIndex = 8;
            this.label1.Text = "Would you like to view a tutorial on how to create recordings?";
            // 
            // rememberChoiceBtn
            // 
            this.rememberChoiceBtn.AutoSize = true;
            this.rememberChoiceBtn.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberChoiceBtn.Location = new System.Drawing.Point(579, 472);
            this.rememberChoiceBtn.Name = "rememberChoiceBtn";
            this.rememberChoiceBtn.Size = new System.Drawing.Size(280, 41);
            this.rememberChoiceBtn.TabIndex = 7;
            this.rememberChoiceBtn.Text = "Don\'t ask me again";
            this.rememberChoiceBtn.UseVisualStyleBackColor = true;
            this.rememberChoiceBtn.CheckedChanged += new System.EventHandler(this.checkChanged);
            // 
            // noBtn
            // 
            this.noBtn.BackColor = System.Drawing.Color.White;
            this.noBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.noBtn.FlatAppearance.BorderSize = 3;
            this.noBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noBtn.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noBtn.Location = new System.Drawing.Point(579, 246);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(220, 220);
            this.noBtn.TabIndex = 6;
            this.noBtn.Text = "No";
            this.noBtn.UseVisualStyleBackColor = false;
            this.noBtn.Click += new System.EventHandler(this.gotoCreate);
            // 
            // yesBtn
            // 
            this.yesBtn.BackColor = System.Drawing.Color.White;
            this.yesBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yesBtn.FlatAppearance.BorderSize = 3;
            this.yesBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesBtn.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesBtn.Location = new System.Drawing.Point(151, 246);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(220, 220);
            this.yesBtn.TabIndex = 5;
            this.yesBtn.Text = "Yes";
            this.yesBtn.UseVisualStyleBackColor = false;
            this.yesBtn.Click += new System.EventHandler(this.gotoTutorial);
            // 
            // FirstTimeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rememberChoiceBtn);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Name = "FirstTimeCreate";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rememberChoiceBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.Button yesBtn;
    }
}

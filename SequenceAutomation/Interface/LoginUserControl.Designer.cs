using System;

namespace SequenceAutomation
{
    partial class LoginUserControl
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
            this.loginCreateRec = new System.Windows.Forms.Button();
            this.loginPlayRec = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loginCreateRec
            // 
            this.loginCreateRec.BackColor = System.Drawing.Color.White;
            this.loginCreateRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginCreateRec.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginCreateRec.FlatAppearance.BorderSize = 3;
            this.loginCreateRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginCreateRec.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginCreateRec.Location = new System.Drawing.Point(597, 258);
            this.loginCreateRec.Name = "loginCreateRec";
            this.loginCreateRec.Size = new System.Drawing.Size(220, 220);
            this.loginCreateRec.TabIndex = 0;
            this.loginCreateRec.Text = "Create a recording";
            this.loginCreateRec.UseVisualStyleBackColor = false;
            this.loginCreateRec.Click += new System.EventHandler(this.gotoCreate);
            // 
            // loginPlayRec
            // 
            this.loginPlayRec.BackColor = System.Drawing.Color.White;
            this.loginPlayRec.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginPlayRec.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loginPlayRec.FlatAppearance.BorderSize = 3;
            this.loginPlayRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginPlayRec.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginPlayRec.Location = new System.Drawing.Point(178, 258);
            this.loginPlayRec.Name = "loginPlayRec";
            this.loginPlayRec.Size = new System.Drawing.Size(220, 220);
            this.loginPlayRec.TabIndex = 1;
            this.loginPlayRec.Text = "Play a recording";
            this.loginPlayRec.UseVisualStyleBackColor = false;
            this.loginPlayRec.Click += new System.EventHandler(this.gotoPlay);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(655, 112);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome!\r\nWhat would you like to do?";
            // 
            // LoginUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginPlayRec);
            this.Controls.Add(this.loginCreateRec);
            this.Name = "LoginUserControl";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loginCreateRec;
        private System.Windows.Forms.Button loginPlayRec;
        private System.Windows.Forms.Label label1;
    }
}

namespace SequenceAutomation
{
    partial class Register
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
            this.goBackBtn = new System.Windows.Forms.Button();
            this.registerBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.firstnameTb = new System.Windows.Forms.RichTextBox();
            this.surnameTb = new System.Windows.Forms.RichTextBox();
            this.password = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.usernameTb = new System.Windows.Forms.RichTextBox();
            this.password1Tb = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.password2Tb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
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
            this.goBackBtn.TabIndex = 97;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBack);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
            // 
            // registerBtn
            // 
            this.registerBtn.BackColor = System.Drawing.Color.White;
            this.registerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerBtn.FlatAppearance.BorderSize = 3;
            this.registerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerBtn.Location = new System.Drawing.Point(420, 644);
            this.registerBtn.Name = "registerBtn";
            this.registerBtn.Size = new System.Drawing.Size(196, 60);
            this.registerBtn.TabIndex = 96;
            this.registerBtn.Text = "Register";
            this.registerBtn.UseVisualStyleBackColor = false;
            this.registerBtn.Click += new System.EventHandler(this.register);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(227, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(338, 41);
            this.label4.TabIndex = 94;
            this.label4.Text = "Create an account";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 37);
            this.label3.TabIndex = 93;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 33);
            this.label2.TabIndex = 92;
            this.label2.Text = "Firstname";
            // 
            // firstnameTb
            // 
            this.firstnameTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstnameTb.Location = new System.Drawing.Point(32, 140);
            this.firstnameTb.Multiline = false;
            this.firstnameTb.Name = "firstnameTb";
            this.firstnameTb.Size = new System.Drawing.Size(408, 31);
            this.firstnameTb.TabIndex = 90;
            this.firstnameTb.Text = "";
            // 
            // surnameTb
            // 
            this.surnameTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surnameTb.Location = new System.Drawing.Point(30, 227);
            this.surnameTb.Multiline = false;
            this.surnameTb.Name = "surnameTb";
            this.surnameTb.Size = new System.Drawing.Size(410, 34);
            this.surnameTb.TabIndex = 91;
            this.surnameTb.Text = "";
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(26, 458);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(304, 37);
            this.password.TabIndex = 101;
            this.password.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 33);
            this.label5.TabIndex = 100;
            this.label5.Text = "Username";
            // 
            // usernameTb
            // 
            this.usernameTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTb.Location = new System.Drawing.Point(32, 404);
            this.usernameTb.Multiline = false;
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(408, 31);
            this.usernameTb.TabIndex = 98;
            this.usernameTb.Text = "";
            // 
            // password1Tb
            // 
            this.password1Tb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password1Tb.Location = new System.Drawing.Point(30, 498);
            this.password1Tb.Multiline = false;
            this.password1Tb.Name = "password1Tb";
            this.password1Tb.Size = new System.Drawing.Size(410, 34);
            this.password1Tb.TabIndex = 99;
            this.password1Tb.Text = "";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(304, 37);
            this.label6.TabIndex = 103;
            this.label6.Text = "Re-type password";
            // 
            // password2Tb
            // 
            this.password2Tb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2Tb.Location = new System.Drawing.Point(32, 604);
            this.password2Tb.Multiline = false;
            this.password2Tb.Name = "password2Tb";
            this.password2Tb.Size = new System.Drawing.Size(410, 34);
            this.password2Tb.TabIndex = 102;
            this.password2Tb.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 37);
            this.label1.TabIndex = 105;
            this.label1.Text = "Email (optional)";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(30, 313);
            this.richTextBox1.Multiline = false;
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(410, 34);
            this.richTextBox1.TabIndex = 104;
            this.richTextBox1.Text = "";
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.password2Tb);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.password1Tb);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.registerBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.firstnameTb);
            this.Controls.Add(this.surnameTb);
            this.Name = "Register";
            this.Size = new System.Drawing.Size(628, 723);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button registerBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox firstnameTb;
        private System.Windows.Forms.RichTextBox surnameTb;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox usernameTb;
        private System.Windows.Forms.RichTextBox password1Tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox password2Tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

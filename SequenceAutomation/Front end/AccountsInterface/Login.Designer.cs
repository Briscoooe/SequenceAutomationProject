namespace SequenceAutomation
{
    partial class Login
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
            this.loginBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.passwordTb = new System.Windows.Forms.TextBox();
            this.usernameTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.White;
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.FlatAppearance.BorderSize = 3;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.Location = new System.Drawing.Point(248, 293);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(196, 60);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.login);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(190, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 41);
            this.label4.TabIndex = 86;
            this.label4.Text = "Login";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(304, 37);
            this.label3.TabIndex = 85;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 33);
            this.label2.TabIndex = 84;
            this.label2.Text = "Username or email adress";
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
            this.goBackBtn.Location = new System.Drawing.Point(2, 3);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(169, 73);
            this.goBackBtn.TabIndex = 89;
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBackEvent);
            this.goBackBtn.MouseEnter += new System.EventHandler(this.goBackBtn_MouseEnter);
            this.goBackBtn.MouseLeave += new System.EventHandler(this.goBackBtn_MouseLeave);
            // 
            // passwordTb
            // 
            this.passwordTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTb.Location = new System.Drawing.Point(36, 218);
            this.passwordTb.Name = "passwordTb";
            this.passwordTb.Size = new System.Drawing.Size(408, 33);
            this.passwordTb.TabIndex = 2;
            this.passwordTb.UseSystemPasswordChar = true;
            // 
            // usernameTb
            // 
            this.usernameTb.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTb.Location = new System.Drawing.Point(36, 130);
            this.usernameTb.Name = "usernameTb";
            this.usernameTb.Size = new System.Drawing.Size(408, 33);
            this.usernameTb.TabIndex = 1;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.usernameTb);
            this.Controls.Add(this.passwordTb);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(515, 415);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordTb;
        private System.Windows.Forms.TextBox usernameTb;
    }
}

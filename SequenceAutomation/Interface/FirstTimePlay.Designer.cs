namespace SequenceAutomation
{
    partial class FirstTimePlay
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
            this.yesBtn = new System.Windows.Forms.Button();
            this.noBtn = new System.Windows.Forms.Button();
            this.rememberChoiceBtn = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesBtn
            // 
            this.yesBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesBtn.Location = new System.Drawing.Point(204, 293);
            this.yesBtn.Name = "yesBtn";
            this.yesBtn.Size = new System.Drawing.Size(173, 161);
            this.yesBtn.TabIndex = 0;
            this.yesBtn.Text = "Yes";
            this.yesBtn.UseVisualStyleBackColor = true;
            this.yesBtn.Click += new System.EventHandler(this.gotoTutorial);
            // 
            // noBtn
            // 
            this.noBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noBtn.Location = new System.Drawing.Point(585, 293);
            this.noBtn.Name = "noBtn";
            this.noBtn.Size = new System.Drawing.Size(171, 161);
            this.noBtn.TabIndex = 1;
            this.noBtn.Text = "No";
            this.noBtn.UseVisualStyleBackColor = true;
            this.noBtn.Click += new System.EventHandler(this.gotoPlay);
            // 
            // rememberChoiceBtn
            // 
            this.rememberChoiceBtn.AutoSize = true;
            this.rememberChoiceBtn.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rememberChoiceBtn.Location = new System.Drawing.Point(585, 474);
            this.rememberChoiceBtn.Name = "rememberChoiceBtn";
            this.rememberChoiceBtn.Size = new System.Drawing.Size(325, 36);
            this.rememberChoiceBtn.TabIndex = 2;
            this.rememberChoiceBtn.Text = "Remember my choice";
            this.rememberChoiceBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(820, 125);
            this.label1.TabIndex = 3;
            this.label1.Text = "Would you like to view a tutorial of how to use the application?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(694, 41);
            this.label2.TabIndex = 4;
            this.label2.Text = "\"Yes\" is recommended for first time users";
            // 
            // FirstTimePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rememberChoiceBtn);
            this.Controls.Add(this.noBtn);
            this.Controls.Add(this.yesBtn);
            this.Name = "FirstTimePlay";
            this.Size = new System.Drawing.Size(990, 530);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button yesBtn;
        private System.Windows.Forms.Button noBtn;
        private System.Windows.Forms.CheckBox rememberChoiceBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

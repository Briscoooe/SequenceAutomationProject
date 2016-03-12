namespace SequenceAutomation
{
    partial class BigMessageBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.messageTimer = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.messageTitle = new System.Windows.Forms.Label();
            this.messageBody = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageTimer
            // 
            this.messageTimer.AutoSize = true;
            this.messageTimer.BackColor = System.Drawing.Color.Transparent;
            this.messageTimer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTimer.Location = new System.Drawing.Point(9, 120);
            this.messageTimer.Name = "messageTimer";
            this.messageTimer.Size = new System.Drawing.Size(0, 16);
            this.messageTimer.TabIndex = 4;
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OkBtn.FlatAppearance.BorderSize = 3;
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.Location = new System.Drawing.Point(167, 207);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(209, 64);
            this.OkBtn.TabIndex = 5;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.Close);
            // 
            // messageTitle
            // 
            this.messageTitle.AutoSize = true;
            this.messageTitle.BackColor = System.Drawing.Color.Transparent;
            this.messageTitle.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTitle.ForeColor = System.Drawing.Color.White;
            this.messageTitle.Location = new System.Drawing.Point(12, 5);
            this.messageTitle.Name = "messageTitle";
            this.messageTitle.Size = new System.Drawing.Size(0, 32);
            this.messageTitle.TabIndex = 8;
            // 
            // messageBody
            // 
            this.messageBody.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBody.Location = new System.Drawing.Point(74, 35);
            this.messageBody.Name = "messageBody";
            this.messageBody.Size = new System.Drawing.Size(388, 138);
            this.messageBody.TabIndex = 9;
            // 
            // BigMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(547, 283);
            this.ControlBox = false;
            this.Controls.Add(this.messageBody);
            this.Controls.Add(this.messageTitle);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.messageTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "BigMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label messageTimer;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label messageTitle;
        private System.Windows.Forms.Label messageBody;
    }
}
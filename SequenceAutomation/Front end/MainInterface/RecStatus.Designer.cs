namespace SequenceAutomation
{
    partial class RecStatus
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
            this.recButtonLabel = new System.Windows.Forms.Label();
            this.stopRecBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recButtonLabel
            // 
            this.recButtonLabel.AutoSize = true;
            this.recButtonLabel.BackColor = System.Drawing.Color.Transparent;
            this.recButtonLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recButtonLabel.Location = new System.Drawing.Point(12, 123);
            this.recButtonLabel.Name = "recButtonLabel";
            this.recButtonLabel.Size = new System.Drawing.Size(208, 37);
            this.recButtonLabel.TabIndex = 9;
            this.recButtonLabel.Text = "Stop recording";
            // 
            // stopRecBtn
            // 
            this.stopRecBtn.BackgroundImage = global::SequenceAutomation.Properties.Resources.stop;
            this.stopRecBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopRecBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopRecBtn.FlatAppearance.BorderSize = 0;
            this.stopRecBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.stopRecBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.stopRecBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopRecBtn.Font = new System.Drawing.Font("Century Gothic", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopRecBtn.Location = new System.Drawing.Point(43, 174);
            this.stopRecBtn.Name = "stopRecBtn";
            this.stopRecBtn.Size = new System.Drawing.Size(150, 150);
            this.stopRecBtn.TabIndex = 8;
            this.stopRecBtn.Tag = "startRecTag";
            this.stopRecBtn.UseVisualStyleBackColor = true;
            this.stopRecBtn.Click += new System.EventHandler(this.showMessage);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "Elapsed time";
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(50, 60);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 40);
            this.timerLabel.TabIndex = 12;
            // 
            // RecStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(240, 336);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.recButtonLabel);
            this.Controls.Add(this.stopRecBtn);
            this.Name = "RecStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Recording Status";
            this.Load += new System.EventHandler(this.RecStatus_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label recButtonLabel;
        private System.Windows.Forms.Button stopRecBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label timerLabel;
    }
}
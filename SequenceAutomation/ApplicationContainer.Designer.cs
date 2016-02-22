using System;

namespace SequenceAutomation
{
    partial class ApplicationContainer
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
            this.createRecUserControl1 = new SequenceAutomation.CreateRecUserControl();
            this.a = new SequenceAutomation.LoginUserControl();
            this.SuspendLayout();
            // 
            // createRecUserControl1
            // 
            this.createRecUserControl1.Location = new System.Drawing.Point(-4, -1);
            this.createRecUserControl1.Name = "createRecUserControl1";
            this.createRecUserControl1.Size = new System.Drawing.Size(990, 530);
            this.createRecUserControl1.TabIndex = 1;
            // 
            // a
            // 
            this.a.Location = new System.Drawing.Point(-4, -1);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(990, 547);
            this.a.TabIndex = 0;
            // 
            // ApplicationContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 541);
            this.Controls.Add(this.a);
            this.Controls.Add(this.createRecUserControl1);
            this.Name = "ApplicationContainer";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginUserControl a;
        private CreateRecUserControl createRecUserControl1;
    }
}
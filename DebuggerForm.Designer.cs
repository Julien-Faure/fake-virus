using System.ComponentModel;

namespace WindowsFormsApp1
{
    partial class DebuggerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.posLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // posLabel
            // 
            this.posLabel.AutoSize = true;
            this.posLabel.Location = new System.Drawing.Point(12, 9);
            this.posLabel.Name = "posLabel";
            this.posLabel.Size = new System.Drawing.Size(46, 17);
            this.posLabel.TabIndex = 0;
            this.posLabel.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // DebuggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 55);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.posLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DebuggerForm";
            this.ShowIcon = false;
            this.Text = "Debugger";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label posLabel;

        private System.Windows.Forms.Label posLabe;

        #endregion
    }
}
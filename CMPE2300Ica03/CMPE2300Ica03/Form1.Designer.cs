﻿namespace CMPE2300Ica03
{
    partial class MyFirstEquals
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
            this.components = new System.ComponentModel.Container();
            this.UI_timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // UI_timer
            // 
            this.UI_timer.Enabled = true;
            this.UI_timer.Interval = 50;
            this.UI_timer.Tick += new System.EventHandler(this.UI_timer_Tick);
            // 
            // MyFirstEquals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MyFirstEquals";
            this.Text = "MyFirstEquals";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer UI_timer;
    }
}


﻿namespace FcNet.FormStyle.Samples
{
    partial class FormSample
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
            this.btnCrud = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrud
            // 
            this.btnCrud.Location = new System.Drawing.Point(407, 34);
            this.btnCrud.Name = "btnCrud";
            this.btnCrud.Size = new System.Drawing.Size(75, 23);
            this.btnCrud.TabIndex = 0;
            this.btnCrud.Text = "CRUD";
            this.btnCrud.UseVisualStyleBackColor = true;
            this.btnCrud.Click += new System.EventHandler(this.btnCrud_Click);
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 381);
            this.Controls.Add(this.btnCrud);
            this.Name = "FormSample";
            this.Text = "FormStyle Samples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrud;
    }
}


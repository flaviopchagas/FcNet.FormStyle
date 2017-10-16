namespace FcNet.FormStyle.Demo
{
    partial class FormDemo
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
            this.btnOrange = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.btnBlue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOrange
            // 
            this.btnOrange.Location = new System.Drawing.Point(12, 12);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(102, 23);
            this.btnOrange.TabIndex = 0;
            this.btnOrange.Text = "Orange";
            this.btnOrange.UseVisualStyleBackColor = true;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // pnlColor
            // 
            this.pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColor.Location = new System.Drawing.Point(12, 41);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(247, 123);
            this.pnlColor.TabIndex = 1;
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(120, 12);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(102, 23);
            this.btnBlue.TabIndex = 2;
            this.btnBlue.Text = "Blue";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // FormDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 358);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.btnOrange);
            this.Name = "FormDemo";
            this.Text = "FcNet - FormStyle Demo";
            this.Load += new System.EventHandler(this.FormDemo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Panel pnlColor;
        private System.Windows.Forms.Button btnBlue;
    }
}


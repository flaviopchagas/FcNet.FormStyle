namespace FcNet.FormStyle.Samples
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
            this.button1 = new System.Windows.Forms.Button();
            this.tabMenu1 = new FcNet.TabMenu.TabMenu();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabMenu1
            // 
            this.tabMenu1.Location = new System.Drawing.Point(359, 170);
            this.tabMenu1.Name = "tabMenu1";
            this.tabMenu1.Size = new System.Drawing.Size(200, 100);
            this.tabMenu1.TabAppearance.BorderSize = 0;
            this.tabMenu1.TabAppearance.CheckedBorderSize = 0;
            this.tabMenu1.TabAppearance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tabMenu1.TabIndex = 2;
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 381);
            this.Controls.Add(this.tabMenu1);
            this.Controls.Add(this.button1);
            this.Name = "FormSample";
            this.Text = "FormStyle Samples";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private TabMenu.TabMenu tabMenu1;
    }
}


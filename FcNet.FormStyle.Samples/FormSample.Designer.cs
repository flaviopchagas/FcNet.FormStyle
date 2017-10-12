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
            this.tabMenu1 = new FcNet.TabMenu.TabMenu();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabMenu1
            // 
            this.tabMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.tabMenu1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabMenu1.Location = new System.Drawing.Point(336, 81);
            this.tabMenu1.Name = "tabMenu1";
            this.tabMenu1.Size = new System.Drawing.Size(319, 41);
            this.tabMenu1.TabAppearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.tabMenu1.TabAppearance.BorderColor = System.Drawing.Color.Transparent;
            this.tabMenu1.TabAppearance.BorderSize = 0;
            this.tabMenu1.TabAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tabMenu1.TabAppearance.CheckedBorderSize = 0;
            this.tabMenu1.TabAppearance.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.tabMenu1.TabAppearance.CheckedMouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tabMenu1.TabAppearance.CheckedMouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(241)))));
            this.tabMenu1.TabAppearance.CheckedMouseOverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154)))));
            this.tabMenu1.TabAppearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(236)))), ((int)(((byte)(241)))));
            this.tabMenu1.TabAppearance.Margin = new System.Windows.Forms.Padding(2, 10, 0, 0);
            this.tabMenu1.TabAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(141)))), ((int)(((byte)(188)))));
            this.tabMenu1.TabAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(64)))), ((int)(((byte)(120)))));
            this.tabMenu1.TabAppearance.TabSize = new System.Drawing.Size(75, 33);
            this.tabMenu1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(212, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 381);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabMenu1);
            this.Name = "FormSample";
            this.Text = "FormStyle Samples";
            this.ResumeLayout(false);

        }

        #endregion

        private TabMenu.TabMenu tabMenu1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}


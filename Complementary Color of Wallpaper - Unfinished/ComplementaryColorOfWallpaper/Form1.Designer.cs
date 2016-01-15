namespace WindowsFormsApplication9
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelAVGLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCompColor = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.compButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get The Color!!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desktop AVG Color :";
            // 
            // labelAVGLabel
            // 
            this.labelAVGLabel.AutoSize = true;
            this.labelAVGLabel.Location = new System.Drawing.Point(124, 12);
            this.labelAVGLabel.Name = "labelAVGLabel";
            this.labelAVGLabel.Size = new System.Drawing.Size(10, 13);
            this.labelAVGLabel.TabIndex = 2;
            this.labelAVGLabel.Text = "-";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Complementary Color :";
            // 
            // labelCompColor
            // 
            this.labelCompColor.AutoSize = true;
            this.labelCompColor.Location = new System.Drawing.Point(133, 29);
            this.labelCompColor.Name = "labelCompColor";
            this.labelCompColor.Size = new System.Drawing.Size(10, 13);
            this.labelCompColor.TabIndex = 4;
            this.labelCompColor.Text = "-";
            // 
            // colorButton
            // 
            this.colorButton.Enabled = false;
            this.colorButton.Location = new System.Drawing.Point(1, 12);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(15, 13);
            this.colorButton.TabIndex = 5;
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // compButton
            // 
            this.compButton.Enabled = false;
            this.compButton.Location = new System.Drawing.Point(1, 31);
            this.compButton.Name = "compButton";
            this.compButton.Size = new System.Drawing.Size(15, 13);
            this.compButton.TabIndex = 6;
            this.compButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 89);
            this.Controls.Add(this.compButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.labelCompColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAVGLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAVGLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCompColor;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button compButton;
    }
}


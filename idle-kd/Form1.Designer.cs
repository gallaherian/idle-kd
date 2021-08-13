namespace idleKD
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
            this.label1 = new System.Windows.Forms.Label();
            this.focusLabel = new System.Windows.Forms.Label();
            this.idleLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.totLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(18, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(122, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "00:00:00";
            // 
            // focusLabel
            // 
            this.focusLabel.AutoSize = true;
            this.focusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusLabel.ForeColor = System.Drawing.Color.Green;
            this.focusLabel.Location = new System.Drawing.Point(0, 25);
            this.focusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.focusLabel.Name = "focusLabel";
            this.focusLabel.Size = new System.Drawing.Size(57, 13);
            this.focusLabel.TabIndex = 1;
            this.focusLabel.Text = "00:00:00";
            // 
            // idleLabel
            // 
            this.idleLabel.AutoSize = true;
            this.idleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idleLabel.ForeColor = System.Drawing.Color.Red;
            this.idleLabel.Location = new System.Drawing.Point(76, 25);
            this.idleLabel.Margin = new System.Windows.Forms.Padding(0);
            this.idleLabel.Name = "idleLabel";
            this.idleLabel.Size = new System.Drawing.Size(57, 13);
            this.idleLabel.TabIndex = 2;
            this.idleLabel.Text = "00:00:00";
            this.idleLabel.MouseHover += new System.EventHandler(this.idleLabel_MouseHover);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // totLabel
            // 
            this.totLabel.AutoSize = true;
            this.totLabel.Location = new System.Drawing.Point(2, 38);
            this.totLabel.Name = "totLabel";
            this.totLabel.Size = new System.Drawing.Size(35, 13);
            this.totLabel.TabIndex = 4;
            this.totLabel.Text = "label2";
            this.totLabel.Click += new System.EventHandler(this.totLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(132, 80);
            this.ControlBox = false;
            this.Controls.Add(this.totLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idleLabel);
            this.Controls.Add(this.focusLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1230, 689);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0.7D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label focusLabel;
        private System.Windows.Forms.Label idleLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totLabel;
    }
}


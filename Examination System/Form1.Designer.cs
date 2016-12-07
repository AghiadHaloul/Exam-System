namespace Examination_System
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
            this.Studentbtn = new System.Windows.Forms.Button();
            this.Teacherbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 59);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(649, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Examination System";
            // 
            // Studentbtn
            // 
            this.Studentbtn.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Studentbtn.Location = new System.Drawing.Point(258, 299);
            this.Studentbtn.Name = "Studentbtn";
            this.Studentbtn.Size = new System.Drawing.Size(150, 150);
            this.Studentbtn.TabIndex = 1;
            this.Studentbtn.Text = "Student";
            this.Studentbtn.UseVisualStyleBackColor = true;
            this.Studentbtn.Click += new System.EventHandler(this.Studentbtn_Click);
            // 
            // Teacherbtn
            // 
            this.Teacherbtn.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Teacherbtn.Location = new System.Drawing.Point(747, 299);
            this.Teacherbtn.Name = "Teacherbtn";
            this.Teacherbtn.Size = new System.Drawing.Size(150, 150);
            this.Teacherbtn.TabIndex = 2;
            this.Teacherbtn.Text = "Teacher";
            this.Teacherbtn.UseVisualStyleBackColor = true;
            this.Teacherbtn.Click += new System.EventHandler(this.Teacherbtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 681);
            this.Controls.Add(this.Teacherbtn);
            this.Controls.Add(this.Studentbtn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Examination Systems";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Studentbtn;
        private System.Windows.Forms.Button Teacherbtn;
    }
}


namespace Foompany.SampleClient.MyApp
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
            this.txt_Hostname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SampleInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_Hostname
            // 
            this.txt_Hostname.Location = new System.Drawing.Point(95, 10);
            this.txt_Hostname.Name = "txt_Hostname";
            this.txt_Hostname.Size = new System.Drawing.Size(152, 20);
            this.txt_Hostname.TabIndex = 9;
            this.txt_Hostname.Text = "localhost:16000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Prism hostname :";
            // 
            // txt_SampleInput
            // 
            this.txt_SampleInput.Location = new System.Drawing.Point(95, 52);
            this.txt_SampleInput.Name = "txt_SampleInput";
            this.txt_SampleInput.Size = new System.Drawing.Size(152, 20);
            this.txt_SampleInput.TabIndex = 7;
            this.txt_SampleInput.Text = "George";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Your name :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(32, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "Do the thing!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 159);
            this.Controls.Add(this.txt_Hostname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_SampleInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client-side app";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Hostname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SampleInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}


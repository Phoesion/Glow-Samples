namespace Foompany.ClientApps.SampleApp2
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
            this.txt_SampleInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Hostname = new System.Windows.Forms.TextBox();
            this.txt_BearerToken = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 240);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(251, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Do the thing!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Your name :";
            // 
            // txt_SampleInput
            // 
            this.txt_SampleInput.Location = new System.Drawing.Point(115, 188);
            this.txt_SampleInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SampleInput.Name = "txt_SampleInput";
            this.txt_SampleInput.Size = new System.Drawing.Size(357, 23);
            this.txt_SampleInput.TabIndex = 2;
            this.txt_SampleInput.Text = "John";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Prism hostname :";
            // 
            // txt_Hostname
            // 
            this.txt_Hostname.Location = new System.Drawing.Point(115, 10);
            this.txt_Hostname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Hostname.Name = "txt_Hostname";
            this.txt_Hostname.Size = new System.Drawing.Size(357, 23);
            this.txt_Hostname.TabIndex = 4;
            this.txt_Hostname.Text = "localhost:16000";
            // 
            // txt_BearerToken
            // 
            this.txt_BearerToken.Location = new System.Drawing.Point(115, 51);
            this.txt_BearerToken.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_BearerToken.Multiline = true;
            this.txt_BearerToken.Name = "txt_BearerToken";
            this.txt_BearerToken.Size = new System.Drawing.Size(357, 131);
            this.txt_BearerToken.TabIndex = 6;
            this.txt_BearerToken.Text = "[ Paste your token here ]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 54);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Bearer token :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 310);
            this.Controls.Add(this.txt_BearerToken);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Hostname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_SampleInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SampleInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Hostname;
        private System.Windows.Forms.TextBox txt_BearerToken;
        private System.Windows.Forms.Label label3;
    }
}


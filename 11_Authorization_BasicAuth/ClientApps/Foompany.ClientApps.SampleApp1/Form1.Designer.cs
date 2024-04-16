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
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            txt_SampleInput = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            txt_Hostname = new System.Windows.Forms.TextBox();
            txt_username = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            txt_password = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(58, 232);
            button1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(358, 65);
            button1.TabIndex = 0;
            button1.Text = "Do the thing!";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(48, 174);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(114, 25);
            label1.TabIndex = 1;
            label1.Text = "Some Input :";
            // 
            // txt_SampleInput
            // 
            txt_SampleInput.Location = new System.Drawing.Point(165, 171);
            txt_SampleInput.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_SampleInput.Name = "txt_SampleInput";
            txt_SampleInput.Size = new System.Drawing.Size(251, 31);
            txt_SampleInput.TabIndex = 2;
            txt_SampleInput.Text = "test_data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 23);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(149, 25);
            label2.TabIndex = 3;
            label2.Text = "Prism hostname :";
            // 
            // txt_Hostname
            // 
            txt_Hostname.Location = new System.Drawing.Point(165, 17);
            txt_Hostname.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_Hostname.Name = "txt_Hostname";
            txt_Hostname.Size = new System.Drawing.Size(251, 31);
            txt_Hostname.TabIndex = 4;
            txt_Hostname.Text = "localhost:16000";
            // 
            // txt_username
            // 
            txt_username.Location = new System.Drawing.Point(165, 60);
            txt_username.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_username.Name = "txt_username";
            txt_username.Size = new System.Drawing.Size(251, 31);
            txt_username.TabIndex = 6;
            txt_username.Text = "bob";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(64, 63);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 25);
            label3.TabIndex = 5;
            label3.Text = "username :";
            // 
            // txt_password
            // 
            txt_password.Location = new System.Drawing.Point(165, 99);
            txt_password.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_password.Name = "txt_password";
            txt_password.Size = new System.Drawing.Size(251, 31);
            txt_password.TabIndex = 8;
            txt_password.Text = "123";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(64, 102);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 25);
            label4.TabIndex = 7;
            label4.Text = "password :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(495, 327);
            Controls.Add(txt_password);
            Controls.Add(label4);
            Controls.Add(txt_username);
            Controls.Add(label3);
            Controls.Add(txt_Hostname);
            Controls.Add(label2);
            Controls.Add(txt_SampleInput);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SampleInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Hostname;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label4;
    }
}


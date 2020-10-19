namespace DesktopAppClient
{
    partial class MainFrm
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
            this.txt_ServerUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Username = new System.Windows.Forms.TextBox();
            this.groupBox_ConnectionSetup = new System.Windows.Forms.GroupBox();
            this.groupBox_Chat = new System.Windows.Forms.GroupBox();
            this.btn_TestComplexMsg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lst_Log = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_SendMessage = new System.Windows.Forms.TextBox();
            this.txt_SendToUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_SendMessage = new System.Windows.Forms.Button();
            this.groupBox_ConnectionSetup.SuspendLayout();
            this.groupBox_Chat.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ServerUrl
            // 
            this.txt_ServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ServerUrl.Location = new System.Drawing.Point(153, 54);
            this.txt_ServerUrl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_ServerUrl.Name = "txt_ServerUrl";
            this.txt_ServerUrl.Size = new System.Drawing.Size(321, 31);
            this.txt_ServerUrl.TabIndex = 0;
            this.txt_ServerUrl.Text = "http://localhost:16000";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-5, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server url :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Login
            // 
            this.btn_Login.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Login.Location = new System.Drawing.Point(293, 167);
            this.btn_Login.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(183, 65);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-5, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Username
            // 
            this.txt_Username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Username.Location = new System.Drawing.Point(153, 108);
            this.txt_Username.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.Size = new System.Drawing.Size(321, 31);
            this.txt_Username.TabIndex = 4;
            this.txt_Username.Text = "appClient1";
            // 
            // groupBox_ConnectionSetup
            // 
            this.groupBox_ConnectionSetup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ConnectionSetup.Controls.Add(this.label1);
            this.groupBox_ConnectionSetup.Controls.Add(this.txt_Username);
            this.groupBox_ConnectionSetup.Controls.Add(this.txt_ServerUrl);
            this.groupBox_ConnectionSetup.Controls.Add(this.label2);
            this.groupBox_ConnectionSetup.Controls.Add(this.btn_Login);
            this.groupBox_ConnectionSetup.Location = new System.Drawing.Point(5, 4);
            this.groupBox_ConnectionSetup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_ConnectionSetup.Name = "groupBox_ConnectionSetup";
            this.groupBox_ConnectionSetup.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_ConnectionSetup.Size = new System.Drawing.Size(493, 260);
            this.groupBox_ConnectionSetup.TabIndex = 5;
            this.groupBox_ConnectionSetup.TabStop = false;
            this.groupBox_ConnectionSetup.Text = "Connection setup";
            // 
            // groupBox_Chat
            // 
            this.groupBox_Chat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Chat.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox_Chat.Controls.Add(this.btn_TestComplexMsg);
            this.groupBox_Chat.Controls.Add(this.label5);
            this.groupBox_Chat.Controls.Add(this.lst_Log);
            this.groupBox_Chat.Controls.Add(this.label3);
            this.groupBox_Chat.Controls.Add(this.txt_SendMessage);
            this.groupBox_Chat.Controls.Add(this.txt_SendToUser);
            this.groupBox_Chat.Controls.Add(this.label4);
            this.groupBox_Chat.Controls.Add(this.btn_SendMessage);
            this.groupBox_Chat.Enabled = false;
            this.groupBox_Chat.Location = new System.Drawing.Point(5, 259);
            this.groupBox_Chat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Chat.Name = "groupBox_Chat";
            this.groupBox_Chat.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox_Chat.Size = new System.Drawing.Size(493, 717);
            this.groupBox_Chat.TabIndex = 6;
            this.groupBox_Chat.TabStop = false;
            this.groupBox_Chat.Text = "Chat";
            // 
            // btn_TestComplexMsg
            // 
            this.btn_TestComplexMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_TestComplexMsg.Location = new System.Drawing.Point(10, 666);
            this.btn_TestComplexMsg.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
            this.btn_TestComplexMsg.Name = "btn_TestComplexMsg";
            this.btn_TestComplexMsg.Size = new System.Drawing.Size(236, 38);
            this.btn_TestComplexMsg.TabIndex = 13;
            this.btn_TestComplexMsg.Text = "Send Complex Message";
            this.btn_TestComplexMsg.UseVisualStyleBackColor = true;
            this.btn_TestComplexMsg.Click += new System.EventHandler(this.btn_TestComplexMsg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 213);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Log :";
            // 
            // lst_Log
            // 
            this.lst_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lst_Log.FormattingEnabled = true;
            this.lst_Log.ItemHeight = 25;
            this.lst_Log.Location = new System.Drawing.Point(15, 246);
            this.lst_Log.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lst_Log.Name = "lst_Log";
            this.lst_Log.Size = new System.Drawing.Size(459, 404);
            this.lst_Log.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 35);
            this.label3.TabIndex = 8;
            this.label3.Text = "Send to User :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SendMessage
            // 
            this.txt_SendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SendMessage.Location = new System.Drawing.Point(153, 90);
            this.txt_SendMessage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_SendMessage.Name = "txt_SendMessage";
            this.txt_SendMessage.Size = new System.Drawing.Size(321, 31);
            this.txt_SendMessage.TabIndex = 10;
            this.txt_SendMessage.Text = "hi";
            // 
            // txt_SendToUser
            // 
            this.txt_SendToUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SendToUser.Location = new System.Drawing.Point(153, 37);
            this.txt_SendToUser.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txt_SendToUser.Name = "txt_SendToUser";
            this.txt_SendToUser.Size = new System.Drawing.Size(321, 31);
            this.txt_SendToUser.TabIndex = 7;
            this.txt_SendToUser.Text = "*";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 38);
            this.label4.TabIndex = 9;
            this.label4.Text = "Message :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SendMessage
            // 
            this.btn_SendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SendMessage.Location = new System.Drawing.Point(293, 148);
            this.btn_SendMessage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_SendMessage.Name = "btn_SendMessage";
            this.btn_SendMessage.Size = new System.Drawing.Size(183, 65);
            this.btn_SendMessage.TabIndex = 6;
            this.btn_SendMessage.Text = "Send Message";
            this.btn_SendMessage.UseVisualStyleBackColor = true;
            this.btn_SendMessage.Click += new System.EventHandler(this.Btn_SendMessage_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 978);
            this.Controls.Add(this.groupBox_Chat);
            this.Controls.Add(this.groupBox_ConnectionSetup);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sample SignalR Desktop App";
            this.groupBox_ConnectionSetup.ResumeLayout(false);
            this.groupBox_ConnectionSetup.PerformLayout();
            this.groupBox_Chat.ResumeLayout(false);
            this.groupBox_Chat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ServerUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Username;
        private System.Windows.Forms.GroupBox groupBox_ConnectionSetup;
        private System.Windows.Forms.GroupBox groupBox_Chat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SendMessage;
        private System.Windows.Forms.TextBox txt_SendToUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_SendMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lst_Log;
        private System.Windows.Forms.Button btn_TestComplexMsg;
    }
}


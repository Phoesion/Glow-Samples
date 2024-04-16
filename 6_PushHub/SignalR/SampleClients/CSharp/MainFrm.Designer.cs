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
            txt_ServerUrl = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btn_Login = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            txt_Username = new System.Windows.Forms.TextBox();
            groupBox_ConnectionSetup = new System.Windows.Forms.GroupBox();
            groupBox_Chat = new System.Windows.Forms.GroupBox();
            btn_Ping = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            lst_Log = new System.Windows.Forms.ListBox();
            label3 = new System.Windows.Forms.Label();
            txt_SendMessage = new System.Windows.Forms.TextBox();
            txt_SendToUser = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            btn_SendMessage = new System.Windows.Forms.Button();
            btn_TestComplexMsg = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            groupBox_Commands = new System.Windows.Forms.GroupBox();
            btn_DownloadFile = new System.Windows.Forms.Button();
            btn_UploadFile = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            groupBox_ConnectionSetup.SuspendLayout();
            groupBox_Chat.SuspendLayout();
            groupBox_Commands.SuspendLayout();
            SuspendLayout();
            // 
            // txt_ServerUrl
            // 
            txt_ServerUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt_ServerUrl.Location = new System.Drawing.Point(153, 44);
            txt_ServerUrl.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_ServerUrl.Name = "txt_ServerUrl";
            txt_ServerUrl.Size = new System.Drawing.Size(371, 31);
            txt_ServerUrl.TabIndex = 0;
            txt_ServerUrl.Text = "http://localhost:16000/ChatService/Chat";
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(-5, 41);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(148, 33);
            label1.TabIndex = 1;
            label1.Text = "Server url :";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_Login
            // 
            btn_Login.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_Login.Location = new System.Drawing.Point(343, 135);
            btn_Login.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new System.Drawing.Size(183, 51);
            btn_Login.TabIndex = 2;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btnLogin_Click;
            // 
            // label2
            // 
            label2.Location = new System.Drawing.Point(-5, 94);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(148, 33);
            label2.TabIndex = 3;
            label2.Text = "Username :";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Username
            // 
            txt_Username.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt_Username.Location = new System.Drawing.Point(153, 89);
            txt_Username.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_Username.Name = "txt_Username";
            txt_Username.Size = new System.Drawing.Size(371, 31);
            txt_Username.TabIndex = 4;
            txt_Username.Text = "appClient1";
            // 
            // groupBox_ConnectionSetup
            // 
            groupBox_ConnectionSetup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox_ConnectionSetup.Controls.Add(label1);
            groupBox_ConnectionSetup.Controls.Add(txt_Username);
            groupBox_ConnectionSetup.Controls.Add(txt_ServerUrl);
            groupBox_ConnectionSetup.Controls.Add(label2);
            groupBox_ConnectionSetup.Controls.Add(btn_Login);
            groupBox_ConnectionSetup.Location = new System.Drawing.Point(5, 4);
            groupBox_ConnectionSetup.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_ConnectionSetup.Name = "groupBox_ConnectionSetup";
            groupBox_ConnectionSetup.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_ConnectionSetup.Size = new System.Drawing.Size(543, 260);
            groupBox_ConnectionSetup.TabIndex = 5;
            groupBox_ConnectionSetup.TabStop = false;
            groupBox_ConnectionSetup.Text = "Connection setup";
            // 
            // groupBox_Chat
            // 
            groupBox_Chat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox_Chat.BackColor = System.Drawing.SystemColors.ControlLight;
            groupBox_Chat.Controls.Add(btn_Ping);
            groupBox_Chat.Controls.Add(label5);
            groupBox_Chat.Controls.Add(lst_Log);
            groupBox_Chat.Controls.Add(label3);
            groupBox_Chat.Controls.Add(txt_SendMessage);
            groupBox_Chat.Controls.Add(txt_SendToUser);
            groupBox_Chat.Controls.Add(label4);
            groupBox_Chat.Controls.Add(btn_SendMessage);
            groupBox_Chat.Enabled = false;
            groupBox_Chat.Location = new System.Drawing.Point(5, 214);
            groupBox_Chat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_Chat.Name = "groupBox_Chat";
            groupBox_Chat.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_Chat.Size = new System.Drawing.Size(543, 487);
            groupBox_Chat.TabIndex = 6;
            groupBox_Chat.TabStop = false;
            groupBox_Chat.Text = "Chat";
            // 
            // btn_Ping
            // 
            btn_Ping.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_Ping.Location = new System.Drawing.Point(327, 441);
            btn_Ping.Margin = new System.Windows.Forms.Padding(0);
            btn_Ping.Name = "btn_Ping";
            btn_Ping.Size = new System.Drawing.Size(197, 40);
            btn_Ping.TabIndex = 14;
            btn_Ping.Text = "Ping user";
            btn_Ping.UseVisualStyleBackColor = true;
            btn_Ping.Click += btn_Ping_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 213);
            label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(51, 25);
            label5.TabIndex = 12;
            label5.Text = "Log :";
            // 
            // lst_Log
            // 
            lst_Log.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lst_Log.FormattingEnabled = true;
            lst_Log.ItemHeight = 25;
            lst_Log.Location = new System.Drawing.Point(15, 245);
            lst_Log.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            lst_Log.Name = "lst_Log";
            lst_Log.Size = new System.Drawing.Size(509, 179);
            lst_Log.TabIndex = 11;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(0, 37);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(143, 35);
            label3.TabIndex = 8;
            label3.Text = "Send to User :";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SendMessage
            // 
            txt_SendMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt_SendMessage.Location = new System.Drawing.Point(153, 90);
            txt_SendMessage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_SendMessage.Name = "txt_SendMessage";
            txt_SendMessage.Size = new System.Drawing.Size(371, 31);
            txt_SendMessage.TabIndex = 10;
            txt_SendMessage.Text = "hi";
            // 
            // txt_SendToUser
            // 
            txt_SendToUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txt_SendToUser.Location = new System.Drawing.Point(153, 37);
            txt_SendToUser.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            txt_SendToUser.Name = "txt_SendToUser";
            txt_SendToUser.Size = new System.Drawing.Size(371, 31);
            txt_SendToUser.TabIndex = 7;
            txt_SendToUser.Text = "*";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(0, 90);
            label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(143, 38);
            label4.TabIndex = 9;
            label4.Text = "Message :";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_SendMessage
            // 
            btn_SendMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_SendMessage.Location = new System.Drawing.Point(343, 148);
            btn_SendMessage.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            btn_SendMessage.Name = "btn_SendMessage";
            btn_SendMessage.Size = new System.Drawing.Size(183, 65);
            btn_SendMessage.TabIndex = 6;
            btn_SendMessage.Text = "Send Message";
            btn_SendMessage.UseVisualStyleBackColor = true;
            btn_SendMessage.Click += Btn_SendMessage_Click;
            // 
            // btn_TestComplexMsg
            // 
            btn_TestComplexMsg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_TestComplexMsg.Location = new System.Drawing.Point(10, 42);
            btn_TestComplexMsg.Margin = new System.Windows.Forms.Padding(0);
            btn_TestComplexMsg.Name = "btn_TestComplexMsg";
            btn_TestComplexMsg.Size = new System.Drawing.Size(516, 40);
            btn_TestComplexMsg.TabIndex = 13;
            btn_TestComplexMsg.Text = "Send Complex Message";
            btn_TestComplexMsg.UseVisualStyleBackColor = true;
            btn_TestComplexMsg.Click += btn_TestComplexMsg_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox_Commands
            // 
            groupBox_Commands.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox_Commands.BackColor = System.Drawing.SystemColors.ControlLight;
            groupBox_Commands.Controls.Add(btn_DownloadFile);
            groupBox_Commands.Controls.Add(btn_UploadFile);
            groupBox_Commands.Controls.Add(button1);
            groupBox_Commands.Controls.Add(btn_TestComplexMsg);
            groupBox_Commands.Controls.Add(button2);
            groupBox_Commands.Controls.Add(button3);
            groupBox_Commands.Enabled = false;
            groupBox_Commands.Location = new System.Drawing.Point(5, 713);
            groupBox_Commands.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_Commands.Name = "groupBox_Commands";
            groupBox_Commands.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            groupBox_Commands.Size = new System.Drawing.Size(543, 199);
            groupBox_Commands.TabIndex = 15;
            groupBox_Commands.TabStop = false;
            groupBox_Commands.Text = "Sample/Test Commands";
            // 
            // btn_DownloadFile
            // 
            btn_DownloadFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_DownloadFile.Location = new System.Drawing.Point(297, 95);
            btn_DownloadFile.Margin = new System.Windows.Forms.Padding(0);
            btn_DownloadFile.Name = "btn_DownloadFile";
            btn_DownloadFile.Size = new System.Drawing.Size(227, 40);
            btn_DownloadFile.TabIndex = 16;
            btn_DownloadFile.Text = "Download File";
            btn_DownloadFile.UseVisualStyleBackColor = true;
            btn_DownloadFile.Click += btn_DownloadFile_Click;
            // 
            // btn_UploadFile
            // 
            btn_UploadFile.Location = new System.Drawing.Point(10, 95);
            btn_UploadFile.Margin = new System.Windows.Forms.Padding(0);
            btn_UploadFile.Name = "btn_UploadFile";
            btn_UploadFile.Size = new System.Drawing.Size(216, 40);
            btn_UploadFile.TabIndex = 15;
            btn_UploadFile.Text = "Upload File";
            btn_UploadFile.UseVisualStyleBackColor = true;
            btn_UploadFile.Click += btn_UploadFile_Click;
            // 
            // button1
            // 
            button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button1.Location = new System.Drawing.Point(279, 610);
            button1.Margin = new System.Windows.Forms.Padding(0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(197, 40);
            button1.TabIndex = 14;
            button1.Text = "Ping user";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button2.Location = new System.Drawing.Point(12, 610);
            button2.Margin = new System.Windows.Forms.Padding(0);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(236, 40);
            button2.TabIndex = 13;
            button2.Text = "Send Complex Message";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button3.Location = new System.Drawing.Point(634, 151);
            button3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(183, 65);
            button3.TabIndex = 6;
            button3.Text = "Send Message";
            button3.UseVisualStyleBackColor = true;
            // 
            // MainFrm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(555, 918);
            Controls.Add(groupBox_Commands);
            Controls.Add(groupBox_Chat);
            Controls.Add(groupBox_ConnectionSetup);
            Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            Name = "MainFrm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Sample SignalR Desktop App";
            groupBox_ConnectionSetup.ResumeLayout(false);
            groupBox_ConnectionSetup.PerformLayout();
            groupBox_Chat.ResumeLayout(false);
            groupBox_Chat.PerformLayout();
            groupBox_Commands.ResumeLayout(false);
            ResumeLayout(false);
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
        private System.Windows.Forms.Button btn_Ping;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_DownloadFile;
        private System.Windows.Forms.Button btn_UploadFile;
        private System.Windows.Forms.GroupBox group_Commands;
        private System.Windows.Forms.GroupBox groupBox_Commands;
    }
}

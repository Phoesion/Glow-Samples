using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using api = Foompany.Services.API.ChatService.Modules.Chat.Actions;
using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;

namespace DesktopAppClient
{
    public partial class MainFrm : Form
    {
        public Phoesion.Glow.SDK.Client.SignalR.GlowClient Client;

        public MainFrm()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            //create client
            Client = new Phoesion.Glow.SDK.Client.SignalR.GlowClient(txt_ServerUrl.Text);
            //register events
            Client.On(topic.ChatMsg, handle_ChatMsg);
            Client.On(topic.Notification, handle_NotificationMsg);
            //start connection
            try
            {
                //start (connect) client
                await Client.Start();
                //register client
                var req = txt_Username.Text;
                var rsp = await Client.Register(api.ClientConnectionRequest, req);
                //connected, enable group boxes
                groupBox_ConnectionSetup.Enabled = false;
                groupBox_Chat.Enabled = true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private async void Btn_SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                //send chat msg
                var toUser = txt_SendToUser.Text;
                var msgText = txt_SendMessage.Text;
                var result = await Client.CallAsync(api.SendMessage, msgText, toUser);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        void handle_ChatMsg(string msg)
        {
            this.Invoke((MethodInvoker)(() => lst_Log.Items.Add(msg)));
        }

        void handle_NotificationMsg(string msg)
        {
            this.Invoke((MethodInvoker)(() => lst_Log.Items.Add("*** " + msg)));
        }
    }
}

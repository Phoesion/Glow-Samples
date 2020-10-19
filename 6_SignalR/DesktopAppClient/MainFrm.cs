using System;
using System.Windows.Forms;

using api = Foompany.Services.API.ChatService.Modules.Chat.Actions;
using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;
using msg = Foompany.Services.API.ChatService.Modules.Chat.Messages;
using Phoesion.Glow.SDK.Client.SignalR;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

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
            //disable connection control
            groupBox_ConnectionSetup.Enabled = false;

            //create client
            var options = new GlowClientOptions()
            {
                ServerUrl = txt_ServerUrl.Text,
                AutoReconnect = true,
                //UseMessagePackProtocol = true,
            };
            Client = new GlowClient(Options.Create(options));

            //setup registration handler
            Client.Registration = registrationHandler;

            //setup incoming events handlers
            Client.On(topic.ChatMsg, handle_ChatMsg);
            Client.On(topic.Notification, handle_NotificationMsg);

            //setup connection events
            Client.Opened += Client_Opened;
            Client.Closed += Client_Closed;

            //start connection
            lst_Log.Items.Add("*** Connecting...");
            await Client.Start();
            lst_Log.Items.Add("*** Connected!");
        }

        async Task Client_Closed()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                groupBox_Chat.Enabled = false;
            }));
        }

        async Task Client_Opened()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                groupBox_Chat.Enabled = true;
            }));
        }

        async Task registrationHandler(GlowClient client)
        {
            var req = new msg.RegistrationRequest() { Username = txt_Username.Text };
            var rsp = await client.Register(api.ClientConnectionRequest, req);
        }

        private async void Btn_SendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                //send chat msg
                var toUser = txt_SendToUser.Text;
                var msgText = new msg.ChatMsg() { Text = txt_SendMessage.Text };
                var result = await Client.Call(api.SendMessage, msgText, toUser).InvokeAsync();
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

        private async void btn_TestComplexMsg_Click(object sender, EventArgs e)
        {
            try
            {
                //send chat msg
                var req = new msg.SampleComplexMsg.Request()
                {
                    Data = "test",
                };
                var result = await Client.Call(api.ComplexMessageSample, req).InvokeAsync();
                //show result
                MessageBox.Show("Result : " + (result?.IsSuccess ?? false) + (result?.Message == null ? null : $"  ({result?.Message})"));
            }
            catch (Exception ex) { MessageBox.Show("EXCEPTION : " + ex.Message); }
        }
    }
}

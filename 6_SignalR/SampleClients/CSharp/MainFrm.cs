using System;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Phoesion.Glow.SDK.Client.SignalR;

using api = Foompany.Services.API.ChatService.Modules.Chat.Actions;
using topic = Foompany.Services.API.ChatService.Modules.Chat.PushTopics;
using msg = Foompany.Services.API.ChatService.Modules.Chat.Messages;

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
            Client = new GlowClient(Options.Create(options), null);

            //setup registration handler
            Client.Registration = registrationHandler;

            //setup incoming events handlers
            Client.On(topic.ChatMsg, handle_ChatMsg);
            Client.On(topic.Notification, handle_NotificationMsg);
            Client.On(topic.Ping, handle_Ping);

            //setup connection events
            Client.Opened += Client_Opened;
            Client.Closed += Client_Closed;

            //start connection
            lst_Log.Items.Add("*** Connecting...");
            try { await Client.StartAsync(); }
            catch (Exception ex) { MessageBox.Show($"Connection failed! ({ex.Message})"); }
        }

        async Task Client_Closed()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                groupBox_Chat.Enabled = false;
                lst_Log.Items.Add("*** Disconnected (Reconnecting...)");
            }));
        }

        async Task Client_Opened()
        {
            this.Invoke((MethodInvoker)(() =>
            {
                lst_Log.Items.Add("*** Connected!");
                groupBox_Chat.Enabled = true;
            }));
        }

        async Task registrationHandler(GlowClient client, CancellationToken cancellationToken)
        {
            var req = new msg.RegistrationRequest() { Username = txt_Username.Text };
            var rsp = await client.RegisterAsync(api.Register, req, cancellationToken);
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

        msg.Ping.Response handle_Ping(msg.Ping.Request req, IRequestHandlerContext ctx)
        {
            this.Invoke((MethodInvoker)(() => lst_Log.Items.Add("*** received ping request from " + req.FromUser)));
            return new msg.Ping.Response()
            {
                IsSuccess = true,
                Nonce = req.Nonce,
            };
        }


        private async void btn_TestComplexMsg_Click(object sender, EventArgs e)
        {
            try
            {
                //send chat msg
                var req = new msg.SampleComplexMsg.Request()
                {
                    Data = "test",
                    MoreData = new System.Collections.Generic.List<msg.SampleComplexMsg.Request.c_MoreData>()
                    {
                         new msg.SampleComplexMsg.Request.c_MoreData()
                         {
                              Data1 = "moredata1",
                              Data2 = 1,
                         },
                         new msg.SampleComplexMsg.Request.c_MoreData()
                         {
                              Data1 = "moredata2",
                              Data2 = 2,
                         }
                    }
                };
                var result = await Client.Call(api.ComplexMessageSample, req).InvokeAsync();
                //show result
                MessageBox.Show("Result : " + (result?.IsSuccess ?? false) + (result?.Message == null ? null : $"  ({result?.Message})"));
            }
            catch (Exception ex) { MessageBox.Show("EXCEPTION : " + ex.Message); }
        }

        private async void btn_Ping_Click(object sender, EventArgs e)
        {
            try
            {
                var user = txt_SendToUser.Text;
                if (string.IsNullOrWhiteSpace(user))
                {
                    MessageBox.Show("Invalid username specified");
                    return;
                }
                if (user == "*")
                {
                    MessageBox.Show("Cannot broadcast ping. You must specify a username");
                    return;
                }
                //create a stopwatch to measure time
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                //send ping request
                var nonce = "1234";
                var result = await Client.Call(api.Ping, user, nonce).InvokeAsync();
                stopwatch.Stop();
                //show result
                MessageBox.Show($"Result : {(result == "1234" ? $"success! round trip time is {stopwatch.ElapsedMilliseconds} ms" : "failed!")}");
            }
            catch (Exception ex) { MessageBox.Show("EXCEPTION : " + ex.Message); }
        }
    }
}

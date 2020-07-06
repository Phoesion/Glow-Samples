using System;
using System.Windows.Forms;

namespace Foompany.ClientApps.SampleApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //create a REST client
            using (var client = new Phoesion.Glow.SDK.Client.REST.GlowClient($"http://{txt_Hostname.Text}"))
            {
                //get access token
                var accessToken = await client.Call(Foompany.Services.API.Authorization.Modules.TokenGenerator.Actions.GetAccessToken, "george", 2).InvokeAsync();
                if (string.IsNullOrWhiteSpace(accessToken))
                {
                    MessageBox.Show($"Could not get access token");
                    return;
                }
                else
                    MessageBox.Show($"Got Access Token : {accessToken}");

                //call service/module action using anonymous api
                var rsp = await client.Call(Foompany.Services.API.SampleService1.Modules.SampleModule1.Actions.DoTheThing, txt_SampleInput.Text)
                                      .WithHeader("Authorization", $"Bearer {accessToken}")
                                      .InvokeAsync();
                if (rsp == null)
                {
                    MessageBox.Show($"Could not reached firefly service");
                    return;
                }
                else
                    MessageBox.Show($"Got Response : {rsp}");
            }
        }
    }
}

using System;
using System.Net.Http;
using System.Windows.Forms;
using IdentityModel.Client;

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
            string accessToken = null;

            //Get access token
            {
                using var client = new HttpClient();

                // discover endpoints from metadata
                //var disco = await client.GetDiscoveryDocumentAsync($"http://{txt_Hostname.Text}/Identity");
                var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
                {
                    Address = $"http://{txt_Hostname.Text}/Identity",   //NOTE: use https in production!
                    //for development purpose, disable HTTPS enforce and validations
                    Policy =
                    {
                        ValidateIssuerName= false,
                        RequireHttps = false,
                    },
                });
                if (disco.IsError)
                {
                    MessageBox.Show($"Could not get DiscoveryDocument : {disco.Error}");
                    return;
                }

                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "secret",

                    Scope = "api1"
                });
                if (tokenResponse.IsError)
                {
                    MessageBox.Show($"Could not get access token: {tokenResponse.Error}");
                    return;
                }

                //keep access token
                MessageBox.Show($"Got access token: {tokenResponse.Json}");
                accessToken = tokenResponse.AccessToken;
            }

            //create a REST client
            using (var client = Phoesion.Glow.SDK.Client.REST.GlowClient.FromBaseUri($"http://{txt_Hostname.Text}"))
            {
                //call service/module action using anonymous api
                var rsp = await client.Call(Foompany.Services.API.SampleService1.Modules.SampleModule1.Actions.DoTheThing, txt_SampleInput.Text)
                                      .WithBearerToken(accessToken)
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

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
            using (var client = Phoesion.Glow.SDK.Client.REST.GlowRestClient.FromBaseUri($"http://{txt_Hostname.Text}"))
            {
                //call service/module action using anonymous api
                var rsp = await client.Call(Foompany.Services.API.SampleService1.Modules.SampleModule1.Actions.DoTheThing, txt_SampleInput.Text)
                                      .WithApiKey(txt_ApiKey.Text);
                if (rsp == null)
                {
                    MessageBox.Show($"Could not reach firefly service");
                    return;
                }
                else
                    MessageBox.Show($"Got Response : {rsp}");
            }
        }
    }
}

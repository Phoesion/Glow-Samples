using System;
using System.Windows.Forms;

namespace Foompany.SampleClient.MyApp
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
            var targetBase = $"http://{txt_Hostname.Text}";
            using (var client = new Phoesion.Glow.SDK.Client.REST.GlowClient(targetBase))
            {
                //call service/module action
                var rsp = await client.Call(Foompany.Services.API.SampleService1.Modules.SampleModule1.Actions.DoTheThing, txt_SampleInput.Text).InvokeAsync();
                if (rsp == null)
                    MessageBox.Show($"Could not reached firefly service");
                else
                    MessageBox.Show($"Got Response : {rsp}");
            }
        }
    }
}

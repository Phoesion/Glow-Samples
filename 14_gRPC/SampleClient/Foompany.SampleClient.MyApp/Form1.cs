using Grpc.Net.Client;
using System;
using System.Windows.Forms;
using Foompany.Services.API.SampleService1.Modules.SampleModule1;

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
            //----------------------------------------
            // NOTE: gRPC requires HTTP/2 and SSL
            //----------------------------------------
            //create gRPC client, targeting the SampleService1/SampleModule1 api
            using var channel = GrpcChannel.ForAddress($"https://{txt_Hostname.Text}");
            var client = new Services.API.SampleService1.Modules.SampleModule1.Actions.ActionsClient(channel);

            //create request
            var req = new HelloRequest { InputName = txt_SampleInput.Text };

            //call 
            var reply = await client.DoTheThingAsync(req);

            //show results
            MessageBox.Show($"Got Response : {reply.Result}");
        }
    }
}

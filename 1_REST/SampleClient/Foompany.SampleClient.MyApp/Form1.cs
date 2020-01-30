using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var client = new Phoesion.Glow.SDK.Client.REST.GlowClient(txt_Hostname.Text, IsSecure: false))
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

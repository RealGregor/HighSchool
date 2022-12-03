using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace ClientTest
{
    public partial class Form1 : Form
    {
        HubConnection connection;

        public Object objekt;

        public Form1()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/status").Build();
            objekt = new Object();
            objekt.Name = "blablalb";
            label1.DataBindings.Add(new Binding("Text", objekt, "Name"));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                await connection.InvokeAsync("SendTime");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var channel = connection.On<string>("ReceiveTime", (time) =>
            {
                this.Invoke((Action)(() =>
                {
                    txtTime.Text = time.ToString();
                }));
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.objekt.Name = "dsfhgteh";
            label1.DataBindings.Clear();
            label1.DataBindings.Add(new Binding("Text", objekt, "Name"));
        }
    }
}

using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using RestSharp;
using SN2UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SN2UI
{
    public partial class Form1 : Form
    {
            
        public HubConnection connection;
        private static readonly HttpClient client = new HttpClient();
        IHubProxy hubProxy;
        BindingList<int> ValidTokens = new BindingList<int>();
        public Form1()
        {

            InitializeComponent();
            
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            validTokens_lb.DataSource = ValidTokens;
            validTokens_lb.DisplayMember = ValidTokens.ToString();


        }

        public async Task Connected()
        {
            var apiKey = await getApiToken(username_tb.Text, password_tb.Text, clientID_tb.Text);
            dynamic resultApiTokenJson = JsonConvert.DeserializeObject<dynamic>(apiKey);
            string apiToken = resultApiTokenJson.access_token;

            connection = new HubConnection("http://localhost:8080/", "token=" + apiToken);
            hubProxy = connection.CreateHubProxy("eventHubLocal");
            await connection.Start();
    }

        private async void connect_Btn_Click(object sender, EventArgs e)
        {
            await Connected();
        }

        public static async Task<string> getApiToken(string username, string password, string clientId)
        {
            var client = new RestClient("http://localhost:8080/api/v1/authorization/tokens");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            request.AddParameter("grant_type", "password");
            request.AddParameter("client_id", clientId);
            request.AddParameter("scope", "offline_access");
            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;

        }

        private void connect_Sub_Click(object sender, EventArgs e)
        {
            hubProxy.Invoke("subscribeToLiveEvents");

            hubProxy.On("liveEvents", t =>
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    event_tb.Clear();
                    event_tb.Text = t.ToString();
                }));
                var token = t.ToString();
                List<EventModel> eventModel = JsonConvert.DeserializeObject<List<EventModel>>(token);

                if (CheckValid(eventModel[0].tokenNumber))
                {
                    MessageBox.Show("This Token Is Valid");
                    //OPENDOOR
                    //SENDEVENT
                }
                MessageBox.Show("Token Not Valid");
            });
        }

        private void addValidToken_btn_Click(object sender, EventArgs e)
        {
            
            ValidTokens.Add(Int32.Parse(tokenNumber_tb.Text));
        }

        private bool CheckValid(int tokenNumber)
        {

            foreach (var item in ValidTokens)
            {
                if (tokenNumber == item)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

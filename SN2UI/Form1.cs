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
    // Net2 third party auth demo, using SignalR
    // Chris Birch - Paxton Access
    // Not production code.

    //This is a demo of the logic for a third party application to handle the token and user auth. This would required a stable
    //link to the Net2 Server. All commands are handled by the server. The access reader will flash red, before the access command is 
    //sent. There is no way around this. 
    public partial class Form1 : Form
    {
            
        public HubConnection connection;
        private static readonly HttpClient client = new HttpClient();
        IHubProxy hubProxy;
        BindingList<int> ValidTokens = new BindingList<int>();
        string apiToken;

        public Form1()
        {

            InitializeComponent();
            
        }

        /// <summary>
        /// Load Form. Set simple listbox to store valid tokens. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private  void Form1_Load(object sender, EventArgs e)
        {
            validTokens_lb.DataSource = ValidTokens;
            validTokens_lb.DisplayMember = ValidTokens.ToString();
        }

       /// <summary>
       /// SignalR connection logic
       /// </summary>
       /// <returns></returns>
        public async Task Connect()
        {
            //Get Api token from Auth endpoint.
            var apiKey = await getApiToken(username_tb.Text, password_tb.Text, clientID_tb.Text);
            dynamic resultApiTokenJson = JsonConvert.DeserializeObject<dynamic>(apiKey);
            //Create a string of the token data
            apiToken = resultApiTokenJson.access_token;

            //Connect to Hub with Auth
            connection = new HubConnection("http://localhost:8080/", "token=" + apiToken);
            hubProxy = connection.CreateHubProxy("eventHubLocal");
            await connection.Start();
    }

        /// <summary>
        /// Connect button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void connect_Btn_Click(object sender, EventArgs e)
        {
            await Connect();
        }

        /// <summary>
        /// Gets API Access token from API
        /// </summary>
        /// <param name="username">Net2 Username</param>
        /// <param name="password">Net2 Password</param>
        /// <param name="clientId">API Client ID</param>
        /// <returns>string of auth response</returns>
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

        /// <summary>
        /// Subcribe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (eventModel[0].eventSubType == 22)
                {
                    if (CheckValid(eventModel[0].tokenNumber))
                    {
                        //Send Open Door command to Net2 API
                        OpenDoor(eventModel[0].deviceId.ToString());

                        //TODO - Add handling for Logging. I would imagine this would be handled by the third party. 
                    }
                }
            });
        }

        private void addValidToken_btn_Click(object sender, EventArgs e)
        {
            
            ValidTokens.Add(Int32.Parse(tokenNumber_tb.Text));
        }

        /// <summary>
        /// Send the command to Net2 to open the door.
        /// </summary>
        /// <param name="doorID">Door Serial Number</param>
        private async void OpenDoor(string doorID)
        {
            var door = new OpenDoor { DoorId = doorID };
            var client = new RestClient("http://localhost:8080//api/v1/commands/door/open");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "bearer "+apiToken);
            var body = JsonConvert.SerializeObject(door);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }

        /// <summary>
        /// Check that the token is valid. Check token number is present in auth list.
        /// </summary>
        /// <param name="tokenNumber"></param>
        /// <returns>true if valid</returns>
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

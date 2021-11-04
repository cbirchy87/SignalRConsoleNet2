using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace SignalRConsoleNet2
{
    internal class Program
    {

        static void Main(string[] args)
        {
        HubConnection connection;

            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:8080/eventHubLocal")
                .WithAutomaticReconnect()
                .Build();
            connection.StartAsync();    
            Console.ReadLine();
        }
    }
}

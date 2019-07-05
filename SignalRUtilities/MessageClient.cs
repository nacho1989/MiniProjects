using Microsoft.AspNet.SignalR.Client;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;


namespace SignalRUtilities.SignalR
{
    public class MessageClient : IDisposable
    {        
        private static HubConnection _connection;
        private static IHubProxy _myhubProxy;
        private static String _hubUrl = string.Empty;
        private static String _hubName = string.Empty;

        public void Initialize()
        {
            _hubUrl = ConfigurationManager.AppSettings["hubUrl"];
            _hubName = ConfigurationManager.AppSettings["hubName"];
        }
        private void StartHub()
        {
            WebApp.Start(_hubUrl);
        }

       

        public async Task CreateConnection()
        {
            try
            {
                StartHub();

                _connection = new HubConnection(_hubUrl, new Dictionary<string, string>()
                {
                    {
                        "clientName", Environment.MachineName.ToString()
                    }
                });

                _myhubProxy = _connection.CreateHubProxy(_hubName);

                _myhubProxy.On("clearXSLTCache", () => ClearXSLTCache());

                await _connection.Start();

                if (_connection.State == ConnectionState.Connected)
                {
                    Console.WriteLine("Connection Established");
                    _connection.Closed += () => Connection_Closed();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured While trying to Log in: {ex.Message}");
            }
            Console.WriteLine("File Watcher Initialized");
        }

        private void ClearXSLTCache()
        {
            
        }

        private void Connection_Closed()
        {
            Console.WriteLine($"Client connection timed out:");
            //wait for 5 secconds and re-establish connection
            Thread.Sleep(5000);
            CreateConnection().Wait();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}

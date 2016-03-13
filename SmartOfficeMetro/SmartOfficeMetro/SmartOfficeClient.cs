using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworksApi.TCP.CLIENT;
using System.Net;
using System.Net.Sockets;
using MahApps.Metro;
using MahApps.Metro.Controls;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Threading;
using System.Threading;
using Newtonsoft.Json;




namespace SmartOfficeMetro
{
    
    public class SmartOfficeClient
    {
        public static Client client;
        private SynchronizationContext _uiContext = SynchronizationContext.Current;
        static JsonSerializer serializer;

       
        public SmartOfficeClient(User user)
        {
            client = new Client();
            client.ServerIp = "172.31.131.100";
            client.ServerPort = "8888";
            client.ClientName = user.Name;

            client.OnClientConnected += Client_OnClientConnected;
            client.OnClientDisconnected += Client_OnClientDisconnected;
            client.OnClientError += Client_OnClientError;
            client.OnClientFileSending += Client_OnClientFileSending;
            client.OnDataReceived += Client_OnDataReceived;
            client.OnClientConnecting += Client_OnClientConnecting;
            
            client.Connect();

            //Initialize JSON object serializer
            serializer = new JsonSerializer();
            
        }
        public static void sendMessage(int requestType, object obj)
        {
            String message = JsonConvert.SerializeObject(obj);
            //String jsonMessage = JsonSerializer
            client.Send(message);
        }

        private void Client_OnClientConnecting(object Sender, ClientConnectingArguments R)
        {
            System.Diagnostics.Debug.WriteLine("Connecting");
        }

        private void Client_OnDataReceived(object Sender, ClientReceivedArguments R)
        {
            _uiContext.Post(new SendOrPostCallback(new Action<object>(o => {
                
                var mainview0 = System.Windows.Application.Current.Windows.OfType<MetroWindow>().FirstOrDefault();
                mainview0.ShowMessageAsync("Notification", R.ReceivedData, MessageDialogStyle.Affirmative);
             })), null);   
        }

        private void Client_OnClientFileSending(object Sender, ClientFileSendingArguments R)
        {
            throw new NotImplementedException();
        }

        private void Client_OnClientError(object Sender, ClientErrorArguments R)
        {
            System.Diagnostics.Debug.WriteLine(R.ErrorMessage);
        }

        private void Client_OnClientDisconnected(object Sender, ClientDisconnectedArguments R)
        {
            System.Diagnostics.Debug.WriteLine(R.EventMessage);
        }

        private void Client_OnClientConnected(object Sender, ClientConnectedArguments R)
        {
            System.Diagnostics.Debug.WriteLine(R.EventMessage);
        }

        public static string GetLocalIPAddress()
        {
            string IP4Address = String.Empty;
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            return IP4Address;
        }



    }
}

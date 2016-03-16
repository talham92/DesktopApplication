using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworksApi.TCP.SERVER;
using System.Net;
using System.Net.Sockets;
using SmartOfficeServer.Model;
using Newtonsoft.Json;
using MySql.Data;
namespace SmartOfficeServer
{
    class TCPServer
    {
        Server server;
        string iPAddress;
        const string port = "8888";
        JSONObject obj;
        DBConnect MySQlConnection;
        //1: Notifications(Any kind) 2: Coffee 3: Login request 4: Mail request 5: BLANK 6: Initial user Data 7: delivery history 8: notification history
        private const int NOTIFICATION_REQUEST = 1;
        private const int COFFEE_REQUEST = 2;
        private const int LOGIN_REQUEST = 3;
        private const int MAIL_REQUEST = 4;
        private const int BLANK = 5;
        private const int INITIAL_USER_DATA = 6;
        private const int DELIVERY_HISTORY = 7;
        private const int NOTIFICATION_HISTORY = 8;
        public static int Main(string[] args)
        {
            
            GetLocalIPAddress();
            TCPServer Init = new TCPServer();
            Console.WriteLine("Begin Server initialization..............");
            Init.initializeServer();
            Console.WriteLine("Begin database initialization............");
            Init.intializeDatabase();
            Console.WriteLine("Ending Initialization...... \nServer setup fully \n==================================");

            List<List<String>> data = new List<List<string>>();
            String name = "raghav";
            
            data = Init.MySQlConnection.SelectAll("user", "id", "username = '" + name + "'; ");

            Console.WriteLine(data.ElementAt(0).ElementAt(0));
            String id = data.ElementAt(0).ElementAt(0);

            data = Init.MySQlConnection.SelectAll("user", "*", "true");

            foreach (List<String> list in data)
            {
                foreach(string d in list)
                {
                    Console.Write(d + "   ");
                }
                Console.WriteLine("");
            }
            //Now we just need to serialize this chunk of data into a JSON object and pass it on to the client
            //JSONObject obj = new JSONObject(DELIVERY_HISTORY, data);
           // return JsonConvert.SerializeObject(obj);



            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
            return 0;

        }

        public void initializeServer()
        {
            //dynamically gets the local IP address of the server
            iPAddress = "172.31.131.100";
            server = new Server(iPAddress, port);
            server.OnClientConnected += Server_OnClientConnected;
            server.OnClientDisconnected += Server_OnClientDisconnected;
            server.OnDataReceived += Server_OnDataReceived;
            server.OnServerError += Server_OnServerError;

            server.Start();
            Console.WriteLine("Server Connected! \n");

        }
        public void intializeDatabase()
        {
            //Open DB connection and display message
            MySQlConnection = new DBConnect();
            if(MySQlConnection.OpenConnection())
            {
                Console.WriteLine("Sucessfully connected to database\n");
            }
            else
            {
                Console.WriteLine("Error connecting to database\n");
            }
        }
        private void Server_OnServerError(object Sender, ErrorArguments R)
        {
            Console.WriteLine(R.ErrorMessage);
        }

        /// <summary>
        /// Executed when the server receives data from a client. based on requestType executes different method stubs
        /// </summary>
        /// <param name="requestType"> 
        /// 1: Notifications(Any kind) 2: Coffee 3: Login request 4: Mail request 5: populate mail service 6: Initial user Data 7: delivery history 8: notification history
        /// </param>
        /// <param name="obj">Desired data</param>
        private void Server_OnDataReceived(object Sender, ReceivedArguments R)
        {
            String response = "";
            Console.WriteLine("I got data from " + R.Name);
            Console.WriteLine(R.ReceivedData.ToString());
            obj = JsonConvert.DeserializeObject<JSONObject>(R.ReceivedData);
            //differentiate data based on the type of request received
            switch(obj.requestType)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine(System.DateTime.Now + ": Coffee delivery requested by " + R.Name);
                    response = Coffee_Handler(obj.info);
                    break;
                case 3:
                    //convert login string to object and pass it to login method to verify
                    Console.WriteLine(System.DateTime.Now + ": Trying to login " + R.Name);
                    response = Login_Handler(obj.info);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Console.WriteLine(System.DateTime.Now + ": Initial user data requested by " + R.Name);
                    response = Initial_user_data_handler(R.Name);
                    break;
                case 7:
                    Console.WriteLine(System.DateTime.Now + ": " + R.Name + "is requesting their delivery history");
                    response = Delivery_History_Handler(R.Name);
                    break;
                case 8:
                    Console.WriteLine(System.DateTime.Now + ": " + R.Name + "is requesting their notification history");
                    response = Notification_History_Handler(R.Name);
                    break;
                    
            }//switch
            server.SendTo(R.Name, response);

        }

        private String Notification_History_Handler(string name)
        {
            List<List<String>> notification;
            //          query = "Select id from user where username='" + name + "';";
            //          needed to get user's ID, will reuse to get notifications
            notification = MySQlConnection.SelectAll("user", "id", "username = '" + name + "'; ");
            //Should only return 1 value
            String id = notification.ElementAt(0).ElementAt(0);
            //            query = "Select * from user, notifications where user.id = 'id' and user.id=notification.id_user limit 50";
            //            get notification history of the user
            notification = MySQlConnection.SelectAll("user,notification n", "n.id_notification,n.id_user,n.id_sender,n.subject,n.description,n.time", "user.id = '" + id + "' and user.id=n.id_user limit 50;");

            //Now we just need to serialize this chunk of data into a JSON object and pass it on to the client
            JSONObject obj = new JSONObject(NOTIFICATION_HISTORY, notification);
            return JsonConvert.SerializeObject(obj);
        }

        private String Delivery_History_Handler(string name)
        {
            List<List<String>> delivery;
            //          query = "Select id from user where username='" + name + "';";
            //          needed to get user's ID, will reuse to get notifications
            delivery = MySQlConnection.SelectAll("user", "id", "username = '" + name + "'; ");
            //Should only return 1 value
            String id = delivery.ElementAt(0).ElementAt(0);
            //          query = "Select * from delivery, user where user.id = id and user.id = delivery.id_user and status = 1 limit 50;"
            //          get delivery history of user
            delivery = MySQlConnection.SelectAll("delivery d,user", "d.id_delivery, d.id_user, d.id_reciver, d.request_type, d.start_time, d.end_time, d.status", "user.id = '" + id + "' and user.id = d.id_user and status = 1 limit 50;");

            //Now we just need to serialize this chunk of data into a JSON object and pass it on to the client
            JSONObject obj = new JSONObject(DELIVERY_HISTORY, delivery);
            return JsonConvert.SerializeObject(obj);
        }

        private String Initial_user_data_handler(string name)
        {
            List<List<String>> user;
            //          query = "Select id from user where username='" + name + "';";
            //          needed to get user's ID, will reuse to get all users
            user = MySQlConnection.SelectAll("user", "id", "username = '" + name + "'; ");
            //Should only return 1 value
            String id = user.ElementAt(0).ElementAt(0);
            //            query = "Select * from user where true"
            //            to fetch all the users in DB
            user = MySQlConnection.SelectAll("user", "*", "true");

            //Now we just need to serialize this chunk of data into a JSON object and pass it on to the client
            JSONObject obj = new JSONObject(INITIAL_USER_DATA, user);
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Checks for login of the user. returns false if entered details are incorrect. true otherwise
        /// Also populates the user object with other details like name, age, department etc
        /// </summary>
        /// <param name="login">User object with username and password initialized</param>
        /// <returns></returns>
        public String Login_Handler(Object login_object)
        {

            String loginString = JsonConvert.SerializeObject(login_object);
            User login = JsonConvert.DeserializeObject<User>(loginString);
            Boolean login_status = false;
            List<List<String>> returnData = null;   //perform binary comparison for case sensitivity
            returnData = MySQlConnection.SelectAll("user","*", "BINARY username='" + login.username + "' and password = '" + login.password + "';");

            /// if an empty set was returned meaning no matches, otherwise atleast 1 set was returned
            /// and the user is legit. We don't have to worry about more than 1 entry being returned
            /// because username field in the database is set to unique so there is no possibility of
            /// duplicates
            if (returnData == null)
            {
                login_status = false; //no matching login found
            }
            else
            {
                login_status = true; //some record was found
                                     //populate user object
                login.id = returnData.ElementAt(0).ElementAt(0);
                login.Name = returnData.ElementAt(0).ElementAt(3);
                login.age = returnData.ElementAt(0).ElementAt(4);
                login.email = returnData.ElementAt(0).ElementAt(5);
                login.phone = returnData.ElementAt(0).ElementAt(6);
                login.department = returnData.ElementAt(0).ElementAt(7);
                login.image = returnData.ElementAt(0).ElementAt(8);
            }
            //create a login object of this information
            loginObject userLogin = new loginObject(login_status, login);
            //convert to standerdized JSON object
            JSONObject obj = new JSONObject(LOGIN_REQUEST, userLogin);
            return JsonConvert.SerializeObject(obj);

        }//end login

        private String Coffee_Handler(object info)
        {
            String destination = info.ToString();
        //Send data to unity

        //Unity
            String response = "Your coffee will arrive soon!";
        //convert to standerdized JSON object for sending
            JSONObject obj = new JSONObject(COFFEE_REQUEST, response);
            return JsonConvert.SerializeObject(obj);

        }

        private void Server_OnClientDisconnected(object Sender, DisconnectedArguments R)
        {
            Console.WriteLine(R.Name + " has disconnected!");
        }

        private void Server_OnClientConnected(object Sender, ConnectedArguments R)
        {
            Console.WriteLine(R.Name + " has connected");
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
            
        }//get iP address




        /*      DATA PRINTING STUB, use as needed
                    foreach(List<string> list in returnData)
            {
               foreach(String data in list)
                {
                    Console.Write(data + " ");
                }
                Console.WriteLine("");
            }
        */
    }//class
}//namespace

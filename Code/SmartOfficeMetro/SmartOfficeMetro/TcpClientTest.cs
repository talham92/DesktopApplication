using System;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

class TcpClientTest {

        
        private const int  portNum = 10116 ;
      //  TcpClient tcpClient = null;
        NetworkStream networkStream = null;

    public void TCPClientTest()
    {

       // tcpClient = new TcpClient();
    }
    public String startReading(String command)
    {
        TcpClient tcpClient = new TcpClient();
        
        String returnData = "";
        ClientPacket packet = new ClientPacket(command) ;
        String jsonString = JsonConvert.SerializeObject(packet);
        String DataToSend = jsonString;
        System.Diagnostics.Debug.Write(jsonString);



        try
        {
            tcpClient.Connect("localhost", portNum);
            networkStream = tcpClient.GetStream();
           
            if (networkStream.CanWrite && networkStream.CanRead)
            {
                if ( DataToSend.Length == 0 ) return "" ;
	 
                Byte[] sendBytes = Encoding.ASCII.GetBytes(DataToSend);
                networkStream.Write(sendBytes, 0, sendBytes.Length);
              
                // Reads the NetworkStream into a byte buffer.
                byte[] bytes = new byte[tcpClient.ReceiveBufferSize];
                int BytesRead = networkStream.Read(bytes, 0, (int) tcpClient.ReceiveBufferSize);
          
                // Returns the data received from the host to the console.
                returnData = Encoding.ASCII.GetString(bytes, 0 , BytesRead);
                //Console.WriteLine("This is what the host returned to you: \r\n{0}", returndata);			
                                
                networkStream.Close();
                tcpClient.Close();
             }
             else if (!networkStream.CanRead)
             {
                Console.WriteLine("You can not write data to this stream");
                tcpClient.Close();
             }
            else if (!networkStream.CanWrite)
            {             
                Console.WriteLine("You can not read data from this stream");
                tcpClient.Close();
            }

            //return data to form
            return returnData;

           } //end try
     catch (SocketException)
        {
            returnData = "Error connecting to server!";
            Console.WriteLine("Sever not available! Socket Exception!");
            return returnData;
         }
    catch (System.IO.IOException)
        {                                       
            Console.WriteLine("Sever not available! IO Exception!");
            returnData = "Input Error! Please try again!";
            return returnData;

        }
    catch (Exception e )
        {
            System.Diagnostics.Debug.WriteLine(e.ToString());
       //   Console.WriteLine(e.ToString());
            returnData = "Error! Please try again or contact the admin";
            return returnData;
        }
        }       // startReading 
} // class TcpClientTest {

class ClientPacket
{
    public String client
    {
        get; set;
    }
    public String stringData { get; set; }
    public ClientPacket(String data)
    {
        client = "user";
        stringData = data;
    }

}
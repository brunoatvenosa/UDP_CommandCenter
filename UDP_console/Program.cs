using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDP_listner;

//https://learn.microsoft.com/en-us/answers/questions/562659/how-can-send-a-udp-broadcast-to-any-ip-address-on.html
namespace UDP_console
{
    internal class Program
    {
        
        Action act;

        public static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
            IPAddress broadcast = IPAddress.Parse("192.168.15.255");
    
            // PROTOCOL FORMAT            
            // ID_sender: 16 caracteres
            // ID_receiver: 16 caracteres
            // command: 16 caracteres
            // content: livre

            string id_sender = "0123456789012345"; // get info from setup.txt 
            string id_receiver = "5432109876543210";
            string command = Protocol.command_resetAll;
            string content = "AZZZZZB";


            // byte[] sendbuf = Encoding.UTF32.GetBytes("0000alvo0000coma");
            byte[] sendbuf = Encoding.UTF32.GetBytes(id_sender + id_receiver + command + content);
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);
    
            socket.SendTo(sendbuf, ep);
    
            Console.WriteLine("Message sent to the broadcast address");
            
        }
        public void getnext()
        {
            act += getnext;
            act.Invoke();
        }
    }
}
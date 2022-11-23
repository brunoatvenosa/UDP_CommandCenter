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
    
            byte[] sendbuf = Encoding.UTF8.GetBytes("0000alvo0000coma");
            IPEndPoint ep = new IPEndPoint(broadcast, 5009);
    
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
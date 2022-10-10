using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
//https://learn.microsoft.com/en-us/answers/questions/562659/how-can-send-a-udp-broadcast-to-any-ip-address-on.html
namespace UDP_console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
            IPAddress broadcast = IPAddress.Parse("192.168.15.255");
    
            byte[] sendbuf = Encoding.UTF32.GetBytes("til ã arroba @ cedilha ç");
            IPEndPoint ep = new IPEndPoint(broadcast, 11000);
    
            s.SendTo(sendbuf, ep);
    
            Console.WriteLine("Message sent to the broadcast address");
        }
    }
}
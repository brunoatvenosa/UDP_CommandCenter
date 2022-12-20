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
        public static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    
            IPAddress broadcast = IPAddress.Parse(args[0]);
    
            byte[] sendbuf = Encoding.UTF8.GetBytes(args[2]);
            IPEndPoint ep = new IPEndPoint(broadcast, Int32.Parse(args[1]));
    
            socket.SendTo(sendbuf, ep);
    
            Console.WriteLine($"Message sent to \n IP: {args[0]}\n Port: {args[1]}\n Message: {args[2]} ");
            Console.ReadKey();

        }
    }
}
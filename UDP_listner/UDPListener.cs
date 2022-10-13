using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
        //https://learn.microsoft.com/en-us/answers/questions/562659/how-can-send-a-udp-broadcast-to-any-ip-address-on.html
public class UDPListener
{
    private const int listenPort = 11000;
        
    public void StartListener()
    {
        UdpClient listener = new UdpClient(listenPort);
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
        
        try
        {
            while (true)
            {
                Console.WriteLine("Waiting for broadcast");
                byte[] bytes = listener.Receive(ref groupEP);
        
                Console.WriteLine($"Received broadcast from {groupEP} :");
                Console.WriteLine($" {Encoding.UTF8.GetString(bytes, 0, bytes.Length)}");
                // Console.WriteLine($"alvo {Encoding.UTF8.GetString(bytes, 0, 8)}");
                // Console.WriteLine($"comando {Encoding.UTF8.GetString(bytes, 9, 16)}");
                // Console.WriteLine($"parametro {Encoding.UTF8.GetString(bytes, 17, 32)}");
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }
}
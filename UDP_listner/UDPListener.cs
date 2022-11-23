using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json.Linq;
using UDP_listner;

//https://learn.microsoft.com/en-us/answers/questions/562659/how-can-send-a-udp-broadcast-to-any-ip-address-on.html
public class UDPListener
{
    private const int listenPort = 5009;
        
    public void StartListener()
    {
        IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, Config.Port);
        UdpClient listener = new UdpClient(groupEP);

        try
        {
            while (true)
            {
                Console.WriteLine($"Escutando a porta {Config.Port}...");
                byte[] bytes = listener.Receive(ref groupEP);
        
                Console.WriteLine($"Recebido de {groupEP} :");
                Console.WriteLine($" {Encoding.UTF8.GetString(bytes, 0, bytes.Length)}");
                var jObj =JObject.Parse(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                
                Console.WriteLine("Comando: " + jObj["Command"].Value<string>());
                Console.WriteLine("Conteudo: " + jObj["Content"].Value<string>());
                Console.WriteLine("ID do alvo: " + jObj["Id_receiver"].Value<int>());
                Console.WriteLine("ID de envio: " + jObj["Id_sender"].Value<int>());

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            listener.Close();
        }
    }
}
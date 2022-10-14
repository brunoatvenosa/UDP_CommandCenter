using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

using UDP_listner;

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
                
                Console.WriteLine("======= Waiting for broadcast =======");
                Console.WriteLine("");
                byte[] bytes = listener.Receive(ref groupEP);
                string input = Encoding.UTF32.GetString(bytes, 0, bytes.Length);
                // string id_sender = input. MANIPULAR A STRING 
                
                Console.WriteLine($"Received broadcast from {groupEP} :");
                Console.WriteLine($"{Encoding.UTF32.GetString(bytes, 0, bytes.Length)}");

                string id_sender = input.Substring(0, 16);
                string id_receiver = input.Substring(16, 16);
                id_receiver = id_receiver.Trim(' ');
                string command = input.Substring(32, 16);
                command = command.Trim(' ');
                string content = input.Substring(48, input.Length - 48);


                DataStructure Stack = new DataStructure();
                Stack.Id_sender = id_sender;
                Stack.Id_receiver = id_receiver;
                Stack.Command = command;
                Stack.Content = content;
                // Console.WriteLine(id_sender);
                // Console.WriteLine(id_receiver);
                // Console.WriteLine(command);
                // Console.WriteLine(content);                
                
                CommandStack.AddToStack(Stack);
                
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            
            Console.WriteLine("********** SOCKET CLOSED **********");
            Console.WriteLine("");
            listener.Close();

        }
    }

    private void CallBack(string command)
    {
        Console.WriteLine("COMMAND = " + command);
    }
}
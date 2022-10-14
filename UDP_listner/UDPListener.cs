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
                Console.WriteLine("=====================");
                Console.WriteLine("Waiting for broadcast");
                Console.WriteLine("=====================");
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

                Command_stack Stack = new Command_stack();
                Stack.Id_sender = id_sender;
                Stack.Id_receiver = id_receiver;
                Stack.Command = command;
                Stack.Content = content;

                
                
                Stack.AddToStack();
                
                // Console.WriteLine(id_sender);
                // Console.WriteLine(id_receiver);
                // Console.WriteLine(command);
                // Console.WriteLine(content);
                
                if (command == Protocol.command_next.Trim())
                {
                    CallBack(Protocol.command_next.Trim());
                }

                if (command == Protocol.command_back.Trim())
                {
                    CallBack(Protocol.command_back.Trim());
                }

                if (command == Protocol.command_play.Trim())
                {
                    CallBack(Protocol.command_play.Trim());
                }

                if (command == Protocol.command_stop.Trim())
                {
                    CallBack(Protocol.command_stop.Trim());
                }

                if (command == Protocol.command_pause.Trim())
                {
                    CallBack(Protocol.command_pause.Trim());
                }
                
                if (command == Protocol.command_resetAll.Trim())
                {
                    CallBack(Protocol.command_resetAll.Trim());
                }
                
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("*************");
            Console.WriteLine("SOCKET CLOSED");
            Console.WriteLine("*************");
            listener.Close();

        }
    }

    private void CallBack(string command)
    {
        Console.WriteLine("COMMAND = " + command);
    }
}
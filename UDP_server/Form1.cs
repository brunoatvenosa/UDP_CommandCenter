using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_send_Click(object sender, EventArgs evt)
        {
// This constructor arbitrarily assigns the local port number.
            UdpClient udpClient = new UdpClient(11000);
            try{
                udpClient.Connect("www.contoso.com", 11000);

                // Sends a message to the host to which you have connected.
                Byte[] sendBytes = Encoding.ASCII.GetBytes("Is anybody there?");

                udpClient.Send(sendBytes, sendBytes.Length);

                // Sends a message to a different host using optional hostname and port parameters.
                UdpClient udpClientB = new UdpClient();
                udpClientB.Send(sendBytes, sendBytes.Length, "AlternateHostMachineName", 11000);

                //IPEndPoint object will allow us to read datagrams sent from any source.
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Blocks until a message returns on this socket from a remote host.
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);

                // Uses the IPEndPoint object to determine which of these two hosts responded.
                Console.WriteLine("This is the message you received " +
                                  returnData.ToString());
                Console.WriteLine("This message was sent from " +
                                  RemoteIpEndPoint.Address.ToString() +
                                  " on their port number " +
                                  RemoteIpEndPoint.Port.ToString());

                udpClient.Close();
                udpClientB.Close();
            }
            catch (Exception e ) {
                Console.WriteLine(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UdpClient udpClient = new UdpClient("core9", 7);
            Byte[] data = Encoding.ASCII.GetBytes("Hello there");
            udpClient.Send(data, data.Length);

            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            Byte[] received = udpClient.Receive(ref RemoteIpEndPoint);
            string output = Encoding.ASCII.GetString(received);

            Console.WriteLine(output);

            udpClient.Close();
        }
    }
}
using System;
using System.Threading;

namespace UDP_listner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listener = new UDPListener();
            listener.StartListener();
            
            Thread InstanceCaller = new Thread(
                new ThreadStart(listener.StartListener));

            // Start the thread.
            InstanceCaller.Start();

            while (true)
            {
                var data = CommandStack.GetFirst();
                if (data != null)
                {
                    if (data.Command == Protocol.command_next.Trim())
                    {
                        MediaControl.Next();
                    }

                    if (data.Command == Protocol.command_back.Trim())
                    {
                        MediaControl.Back();
                    }
                    
                }
            }
            {
                
            }
            
        }

       
    }
}
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

            
        }

       
    }
}
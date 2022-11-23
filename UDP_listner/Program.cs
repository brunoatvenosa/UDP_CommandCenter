using System;
using System.Threading;

namespace UDP_listner
{
    internal class Program
    {

        public static void Main(string[] args)
        {

            // if (args.Length == 1)
            // {
            //     Config.Port = Int32.Parse(args[0]);
            // }
            // else
            // {
            //     Config.Port = 5009;
            // }
            
            var listener = new UDPListener();
            
            Thread InstanceCaller = new Thread(
                new ThreadStart(listener.StartListener));
            
            InstanceCaller.Start();

        }

       
    }
}
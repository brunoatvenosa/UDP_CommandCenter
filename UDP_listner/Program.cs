namespace UDP_listner
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var listener = new UDPListener();
            listener.StartListener();
        }
    }
}
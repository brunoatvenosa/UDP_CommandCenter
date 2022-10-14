using System;
using System.Security.Policy;

namespace UDP_listner
{
    public class Command_stack
    {
        private string id_sender;
        private string id_receiver;
        private string command;
        private string content;

        public string Id_sender
        {
            get => id_sender;
            set => id_sender = value;
        }

        public string Id_receiver
        {
            get => id_receiver;
            set => id_receiver = value;
        }

        public string Command
        {
            get => command;
            set => command = value;
        }

        public string Content
        {
            get => content;
            set => content = value;
        }

        public void AddToStack()
        {
            Console.WriteLine("Receiver: " + Id_receiver);
        }
    

}
}
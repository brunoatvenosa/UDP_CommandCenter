namespace UDP_listner
{
    public static class Protocol
    {

        public static string command_next = "next".PadLeft(16, ' ');
        public static string command_back = "back".PadLeft(16, ' ');
        
        public static string command_play = "play".PadLeft(16, ' '); 
        public static string command_stop = "stop".PadLeft(16, ' ');
        public static string command_pause = "pause".PadLeft(16, ' ');
        
        public static string command_resetAll = "resetAll".PadLeft(16, ' '); //RESET ALL PRESENTATIONS TO 1 SLIDE


    }
}
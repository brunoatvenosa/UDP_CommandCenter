using System;

namespace UDP_listner
{
    public class MediaControl
    {
        public static void Next()
        {
            Console.WriteLine("########### Elementos Queue ###########");
            Console.WriteLine("");                    
            CommandStack.ShowStack();
        }

        public static void Back()
        {
            CommandStack.GetFirst();
        }
        
        public static void Play()
        {

        }
        
        public static void Stop()
        {

        }
        
        public static void Pause()
        {

        }
    }
}
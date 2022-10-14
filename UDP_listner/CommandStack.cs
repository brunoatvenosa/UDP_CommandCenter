using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace UDP_listner
{

    public class CommandStack
    {
        public static Queue<DataStructure> strQ = new Queue<DataStructure>();

        public static void AddToStack(DataStructure input)
        {
            // Console.WriteLine("Receiver: " + DataStructure.Id_receiver);
            strQ.Enqueue(input);

        }

        public static DataStructure GetFirst()
        {
            return strQ.Dequeue();
        }

        public static void ShowStack()
        {
            Console.WriteLine("Total elements: {0}", strQ.Count); //prints 5

            while (strQ.Count > 0)
            {
                Console.WriteLine(GetFirst()); 
            }
                
            Console.WriteLine("Total elements: {0}", strQ.Count); //prints 0

        }
        
}
}
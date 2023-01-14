using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selfHostingClient
{
    class Program
    {
        static myInterfaceClient myPxy = new myInterfaceClient();
        static int attempts; 
        static void Main(string[] args)
        {
           
            int num = myPxy.SecretNumber(1, 10);
            Console.WriteLine("Secret number is {0}", num);
        }

        public static string makeGuess()
        {
            return "";
        }

        public static string checkGuess()
        {
            
            return ""; 
        }
    }
}

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

            //int num = myPxy.SecretNumber(1, 10);
            int num = makeGuess(); 
            Console.WriteLine("Guess is {0}", num);
        }

        public static int makeGuess()
        {
            Console.WriteLine("Please enter a guess");
            int guess = Int32.Parse(Console.ReadLine()); 
            return guess;
        }

        public static string checkGuess()
        {
            
            return ""; 
        }
    }
}

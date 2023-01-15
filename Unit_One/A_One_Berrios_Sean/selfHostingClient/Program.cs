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

            playGame();
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

        public static void playGame()
        {
            Console.WriteLine("Welcome To Number Guessing Game");
            Console.WriteLine("Enter Lower Limit: ");
            int lower = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Upper Limit: ");
            int upper = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Upper = {0} \n Lower = {1}",upper,lower);
        }
    }
}

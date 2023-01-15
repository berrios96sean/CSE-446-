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
        static int attempts = 0;
        static bool gameOver = false; 
        static void Main(string[] args)
        {
            while (true)
            {
                if (gameOver == false)
                {
                    playGame();
                }
                else
                {
                    Console.WriteLine("If you would like to play the game again press <y>");
                    if (Console.ReadLine() == "y")
                    {
                        playGame();
                    }
                    else
                    {
                        return;
                    }
                }

            }

        }

        public static int makeGuess()
        {
            Console.WriteLine("Please enter a guess");
            int guess = Int32.Parse(Console.ReadLine()); 
            return guess;
        }


        public static string checkGuess(int guess, int num)
        {
            string result = myPxy.checkNumber(guess, num);
            return result; 
        }

        public static void playGame()
        {

            Console.WriteLine("Welcome To Number Guessing Game");
            Console.WriteLine("Enter Lower Limit: ");
            int lower = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter Upper Limit: ");
            int upper = Int32.Parse(Console.ReadLine());
            int num = myPxy.SecretNumber(lower, upper);
            string res = ""; 
            while (res != "correct")
            {
                int guess = makeGuess();
                res = checkGuess(guess, num);
                Console.WriteLine(res);
                attempts++;
            }
            gameOver = true; 

        }
    }
}

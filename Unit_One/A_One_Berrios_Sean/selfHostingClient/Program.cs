using System;
using System.ServiceModel;

namespace selfHostingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            myInterfaceClient myPxy = new myInterfaceClient();
            double pi = myPxy.PiValue();
            Int32 test1 = 27;
            Int32 test2 = -132;
            Int32 result1 = myPxy.absValue(test1);
            Int32 result2 = myPxy.absValue(test2);
            Console.WriteLine("PI value = {0}",pi);
            Console.WriteLine("Abs Values of {0} is {1} and of {2} is {3}", test1, result1, test2, result2);
            myPxy.Close();
            Console.WriteLine("\nPress <ENTER> to terminate the client.\n");
        }
    }
}

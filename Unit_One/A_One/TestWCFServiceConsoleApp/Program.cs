using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWCFServiceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client myPxy = new ServiceReference1.Service1Client();
            string str = myPxy.Hello();
            double pi = myPxy.PiValue();
            Int32 test1 = 27;
            Int32 test2 = -132;
            Int32 result1 = myPxy.absValue(test1);
            Int32 result2 = myPxy.absValue(test2);
            Console.WriteLine("Hello returns {0}", str);
            Console.WriteLine("PI value = {0}", pi );
            Console.WriteLine("Abs Values 0f {0} is {1} and of {2} is {3}", test1,result1,test2,result2);
            myPxy.Close(); 
        }
    }
}

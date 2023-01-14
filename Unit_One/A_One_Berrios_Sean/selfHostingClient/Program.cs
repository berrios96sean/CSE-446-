using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selfHostingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            myInterfaceClient myPxy = new myInterfaceClient();
            int num = myPxy.SecretNumber(1, 10);
            Console.WriteLine("Secret number is {0}", num);
        }
    }
}

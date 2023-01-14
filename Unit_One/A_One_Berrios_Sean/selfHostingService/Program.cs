using System;
using System.ServiceModel;
using System.ServiceModel.Description; 

namespace selfHostingService
{
    [ServiceContract]
    public interface myInterface
    {
        [OperationContract]
        int SecretNumber(int lower, int upper);

        [OperationContract]
        string checkNumber(int userNum, int SecretNum);
    }

    public class myService : myInterface
    {
        public int SecretNumber(int lower, int upper)
        {
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(lower, upper);
            return sNumber;
        }
        public string checkNumber(int userNum, int SecretNum)
        {
            if (userNum == SecretNum)
                return "correct";
            else
            if (userNum > SecretNum)
                return "too big";
            else return "too small";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/Service");
            ServiceHost selfHost = new ServiceHost(typeof(myService), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(myInterface), new WSHttpBinding(), "myService");
                System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);
                selfHost.Open();
                Console.WriteLine("My Service is ready to take requests. Please create a client to call my tnt SecretNumber(int,int) service or string CheckNumber(int,int) service. ");
                Console.WriteLine("If you want to quit this service, press <ENTER>. \n");
                Console.ReadLine();
                selfHost.Close(); 
            }
            catch(CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}

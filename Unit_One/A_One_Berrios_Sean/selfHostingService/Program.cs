using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace selfHostingService
{
    [ServiceContract]
    public interface myInterface
    {
        [OperationContract]
        double PiValue();

        [OperationContract]
        int absValue(int intVal);
    }

    public class myService : myInterface
    {
        public double PiValue()
        {
            double pi = System.Math.PI;
            return (pi);
        }

        public int absValue(int x)
        {
            if (x >= 0) return (x);
            else return (-x); 
        }

        class Program
        {
            static void Main(string[] args)
            {
                Uri baseAddress = new Uri("http://localhost:8000/Service");
                ServiceHost selfHost = new ServiceHost(typeof(myService),baseAddress);

                try
                {
                    selfHost.AddServiceEndpoint(typeof(myInterface),new WSHttpBinding(),"myService");
                    System.ServiceModel.Description.ServiceMetadataBehavior smb = new System.ServiceModel.Description.ServiceMetadataBehavior();
                    smb.HttpGetEnabled = true;
                    selfHost.Description.Behaviors.Add(smb);
                    selfHost.Open();
                    Console.WriteLine("My Service is ready to take requests. Please Create a client to call my double PiValue() service or int absValue(int) service");
                    Console.WriteLine("If you want to quit this service simply press <Enter>. \n ");
                    Console.ReadLine();
                    selfHost.Close(); 
                }
                catch(CommunicationException ce)
                {
                    Console.WriteLine("An Exception occurred: {0}", ce.Message);
                    selfHost.Abort(); 
                }
            }
        }
    }
}

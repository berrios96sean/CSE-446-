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
    }
}

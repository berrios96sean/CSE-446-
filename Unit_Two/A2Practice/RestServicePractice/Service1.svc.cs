﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestServicePractice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
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

        public int addition(int x, int y)
        {
            return (x + y); 
        }
    }
}

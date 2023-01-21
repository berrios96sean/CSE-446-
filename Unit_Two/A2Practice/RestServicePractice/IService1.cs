using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestServicePractice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet]
        double PiValue();

        [OperationContract]
        [WebGet(UriTemplate = "absValue?x={x}")]
        int absValue(int x);

        [OperationContract]
        [WebGet(UriTemplate = "add2?x={x}&y={y}")]
        int addition(int x, int y); 
    }



}


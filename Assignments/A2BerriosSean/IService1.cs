using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A2BerriosSean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "secretNum?lower={lower}&upper={upper}",RequestFormat =WebMessageFormat.Xml,ResponseFormat =WebMessageFormat.Xml,BodyStyle = WebMessageBodyStyle.Bare)]
        int SecretNumber(int lower, int upper);

        [OperationContract]
        [WebGet(UriTemplate = "checkNum?userNum={userNum}&secretNum={secretNum}",RequestFormat =WebMessageFormat.Xml,ResponseFormat =WebMessageFormat.Xml,BodyStyle =WebMessageBodyStyle.Bare)]
        string checkNumber(int userNum, int secretNum);

        // TODO: Add your service operations here
    }



    
}

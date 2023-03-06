using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A4BerriosSean
{
    public interface IService1
    {
        [OperationContract]
        [WebGet(UriTemplate = "SendMessage/{senderID/{recID}/{msg}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        void SendMessage(string senderID, string recID, string msg);

        [OperationContract]
        [WebGet(UriTemplate = "ReceiveMessage/{recID}/{purge}", RequestFormat = WebMessageFormat.Xml, ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Bare)]
        string[] ReceiveMessage(string recID, bool purge);
    }

}

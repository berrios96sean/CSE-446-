using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A8_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Dictionary<string, int> map(string input);

        [OperationContract]
        Dictionary<string, int> reduce(Dictionary<string, int> input);

        [OperationContract]
        string combine(Dictionary<string, int> input);

 
    }

}

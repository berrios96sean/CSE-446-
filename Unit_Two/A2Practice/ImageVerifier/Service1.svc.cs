using System;
using System.IO; 
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Drawing;
using System.Net; 

namespace ImageVerifier
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetVerifierString(string myLength)
        {
            Uri baseUri = new Uri("http://venus.sod.asu.edu/WSRepository/Services/RandomString/Service.svc");
            UriTemplate myTemplate = new UriTemplate("GetRandomString/{Length}");
            Uri completeUri = myTemplate.BindByPosition(baseUri, myLength);
            WebClient proxy = new WebClient();
            byte[] abc = proxy.DownloadData(completeUri);
            Stream strm = new MemoryStream(abc);
            DataContractSerializer obj = new DataContractSerializer(typeof(string));
            string randString = obj.ReadObject(strm).ToString();
            return randString; 

        }

        public Stream GetImage(string myString)
        {

        }
        
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;

namespace A2BerriosSean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        // Create message cache using Dictionary to store Messages 
        private Dictionary<string, List<Message>> messageCache = new Dictionary<string, List<Message>>();

        public void SendMessage(string senderID, string recID, string msg)
        {
            Message message = new Message(senderID, recID, msg, DateTime.UtcNow);

            if (messageCache.ContainsKey(recID) == false)
            {
                Console.WriteLine("Creating a recID");
                messageCache.Add(recID, new List<Message>());
            }

            Console.WriteLine("Creating Message");
            messageCache[recID].Add(message);

            Console.WriteLine("Creating xml");
            createXml();
        }

        public string[] ReceiveMessage(string recID, string purge)
        {
            bool isPurge = Convert.ToBoolean(purge);
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "msg.xml");
            XDocument xDoc = XDocument.Load(filePath);
            var msgs = from message in xDoc.Descendants("rec")
                       where (string)message.Attribute("ID") == recID
                       select message; 

            if (msgs.Any() == false)
            {
                return new string[] { "Receiver ID not found in xml file" };
            }

            
            List<string> msgNotRec = new List<string>();

            foreach (var  m in msgs.Elements("message"))
            {
                string senderID = m.Element("senderID").Value;
                string msg = m.Element("msg").Value;
                string timestamp = m.Element("timestamp").Value;

                msgNotRec.Add(String.Format("{0} [{1}]: {2}", senderID, timestamp, msg));
            }

            if (isPurge)
            {
                msgs.Remove();
                xDoc.Save(filePath);
            }

            return msgNotRec.ToArray();
        }

        #region Helper Methods
        public void createXml()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "msg.xml");
            XDocument xd; 

            if (File.Exists(filePath))
            {
                xd = XDocument.Load(filePath);
            }
            else
            {
                xd =  new XDocument(new XElement("messages"));
            }

            // Get messages from message Cache and create an XML File 
            foreach (KeyValuePair<string, List<Message>> pair in messageCache)
            {

                string recID = pair.Key;
                List<Message> m = pair.Value;

                XElement rElement = new XElement("rec", new XAttribute("ID", recID));

                foreach (Message msg in m)
                {
                    XElement mElement = new XElement("message",
                        new XElement("senderID", msg.senderID),
                        new XElement("msg", msg.text),
                        new XElement("timestamp", msg.timestamp));

                    rElement.Add(mElement);
                }
               // xd.Add(rElement);
                xd.Root.Add(rElement);
            }

       
            xd.Save(filePath);
        }

        #endregion
    }
}

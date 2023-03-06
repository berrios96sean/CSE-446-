using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq; 

namespace A4BerriosSean
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
                messageCache.Add(recID, new List<Message>());
            }

            messageCache[recID].Add(message);

            createXml(); 
        }

        public string[] ReceiveMessage(string recID, bool purge)
        {
            if (messageCache.ContainsKey(recID) == false)
            {
                return null; 
            }

            List<Message> msg = messageCache[recID];
            List<string> msgNotRec = new List<string>(); 

            foreach (Message m in msg)
            {
                if (m.isReceived == false)
                {
                    msgNotRec.Add(String.Format("{0} [{1}]: {2}", m.getSenderID(), m.getTimestamp(), m.getText()));
                    m.isReceived = true; 
                }
            }

            if (purge)
            {
                messageCache.Remove(recID);
                createXml(); 
            }

            return msgNotRec.ToArray(); 
        }

        #region Helper Methods
        public void createXml()
        {
            XDocument xd = new XDocument(new XElement("messages"));

            // Get messages from message Cache and create an XML File 
            foreach (KeyValuePair<string,List<Message>> pair in messageCache)
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
                xd.Root.Add(rElement);
            }
            xd.Save("msg.xml");
        }

        #endregion
    }
}

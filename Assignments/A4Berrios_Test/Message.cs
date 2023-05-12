using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace A2BerriosSean
{
    public class Message
    {

        #region Public Variables 
        public string senderID;
        public string recID;
        public string text;
        public DateTime timestamp;
        public bool isReceived { get; set; }
        #endregion

        #region Constructors 

        public Message()
        {

        }

        public Message(string senderID, string recID, string text, DateTime timestamp)
        {
            this.senderID = senderID;
            this.recID = recID;
            this.text = text;
            this.timestamp = timestamp;
        }
        #endregion

        #region Public Setters 

        public void setTime(DateTime ts)
        {
            this.timestamp = ts;
        }
        public void setSenderID(string senderID)
        {
            this.senderID = senderID;
        }

        public void setRecID(string recID)
        {
            this.recID = recID;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        #endregion

        #region Public Getters 

        public DateTime getTimestamp()
        {
            return this.timestamp;
        }

        public string getSenderID()
        {
            return this.senderID;
        }

        public string getRecID()
        {
            return this.recID;
        }

        public string getText()
        {
            return this.text;
        }

        #endregion

    }
}
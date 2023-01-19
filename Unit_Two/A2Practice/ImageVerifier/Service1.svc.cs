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
            WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
            int mapwidth = (int)(myString.Length * 25);
            Bitmap bMap = new Bitmap(mapwidth, 40);
            Graphics graph = Graphics.FromImage(bMap);
            graph.Clear(Color.Azure);
            graph.DrawRectangle(new Pen(Color.LightBlue, 0), 0, 0, bMap.Width - 1, bMap.Height - 1);
            Random rand = new Random();
            Pen badPen = new Pen(Color.LightGreen, 0); 
            for (int i = 0; i < 100; i++)
            {
                int x = rand.Next(1, bMap.Width - 1);
                int y = rand.Next(1, bMap.Height - 1);
                graph.DrawRectangle(badPen, x, y, 4, 3);
                graph.DrawEllipse(badPen, x, y, 2, 3); 
            }
            char[] charString = myString.ToCharArray();
            Font font = new Font("Boopee", 18, FontStyle.Bold);
            Color[] clr = { Color.Black, Color.Red, Color.DarkViolet, Color.Green, Color.DarkOrange, Color.Brown, Color.Goldenrod, Color.Plum }; 
            for (int i = 0; i < myString.Length; i++)
            {
                int d = rand.Next(20, 25);
                int p = rand.Next(1, 15);
                int c = rand.Next(0, 7);
                string str1 = Convert.ToString(charString[i]);
                Brush b = new System.Drawing.SolidBrush(clr[c]);
                graph.DrawString(str1, font, b, 1 + i * d, p);
            }
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0;
            graph.Dispose();
            bMap.Dispose();
            return ms; 
        }
        
    }
}

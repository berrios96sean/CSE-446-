using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace A8_Berrios_Sean
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();

            string input = "";
            using (StreamReader reader = new StreamReader(FileUpload1.FileContent))
            {
                input = reader.ReadToEnd();
            }

            int numThreads = int.Parse(TextBox1.Text);

            int size = (int)Math.Ceiling((double)input.Length / numThreads);
            List<string> split = new List<string>();

            // split into series of chunks
            for (int i = 0; i < input.Length; i += size)
            {
                if (i + size > input.Length)
                {
                    size = input.Length - i;
                }

                string chunk = input.Substring(i, size);
                split.Add(chunk);
            }

            List<Dictionary<string, int>> maps = new List<Dictionary<string, int>>();
            List<Dictionary<string, int>> reduces = new List<Dictionary<string, int>>();

            foreach (string chunk in split)
            {
                ServiceReference1.Service1Client mySvc1 = new ServiceReference1.Service1Client();
                Dictionary<string, int> mapResult = mySvc1.map(chunk);
                maps.Add(mapResult);
            }

            foreach (Dictionary<string, int> mapResult in maps)
            {
                ServiceReference1.Service1Client mySvc2 = new ServiceReference1.Service1Client();
                Dictionary<string, int> reduceResult = mySvc2.reduce(mapResult);
                reduces.Add(reduceResult);
            }

            Dictionary<string, int> combined = new Dictionary<string, int>();

            foreach (Dictionary<string, int> reduceResult in reduces)
            {
                foreach (KeyValuePair<string, int> kvp in reduceResult)
                {
                    if (combined.ContainsKey(kvp.Key))
                    {
                        combined[kvp.Key] += kvp.Value;
                    }
                    else
                    {
                        combined.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            ServiceReference1.Service1Client mySvc3 = new ServiceReference1.Service1Client();
            string jsonResult = mySvc3.combine(combined);
            Label1.Text =  jsonResult;


        }


    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A8_Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public Dictionary<string,int> map(string input)
        {
            Dictionary<string, int> keyVaules = new Dictionary<string, int>();
            string[] strArr = input.ToLower().Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in strArr)
            {
                if(keyVaules.ContainsKey(word))
                {
                    keyVaules[word]++;
                }
                else
                {
                    keyVaules.Add(word, 1);
                }
            }

            return keyVaules;
        }

        public Dictionary<string, int> reduce(Dictionary<string, int> input)
        {

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> kvp in input)
            {
                string lowerWord = kvp.Key.ToLower();

                if (wordCounts.ContainsKey(lowerWord))
                {
                    wordCounts[lowerWord] += kvp.Value;
                }
                else
                {
                    wordCounts.Add(lowerWord, kvp.Value);
                }
            }

            return wordCounts;
        }



        public string combine(Dictionary<string, int> input)
        {

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (KeyValuePair<string, int> kvp in input)
            {
                string lowerWord = kvp.Key.ToLower();

                if (wordCounts.ContainsKey(lowerWord))
                {
                    wordCounts[lowerWord] += kvp.Value;
                }
                else
                {
                    wordCounts.Add(lowerWord, kvp.Value);
                }
            }

            return JsonConvert.SerializeObject(wordCounts);
        }


    }
}

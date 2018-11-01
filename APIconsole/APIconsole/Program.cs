using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIconsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string result = GetRequest("http://free.currencyconverterapi.com/api/v5/convert?q=USD_EUR&compact=y").Result;

            JsonObject output = JsonConvert.DeserializeObject<JsonObject>(result);
            Console.WriteLine(output.USD_EUR.val);

        }

        async static Task<string> GetRequest(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                Console.WriteLine("client created");
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    Console.WriteLine("response created");
                    using (HttpContent content = response.Content)
                    {
                        string mycontent = await content.ReadAsStringAsync();
                        //Console.WriteLine(mycontent);
                        return mycontent;
                    }
                }


            }
        }
    }
}

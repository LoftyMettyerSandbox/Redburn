using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TradeStreamConsole
{
    class Program
    {

        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var tradeStreamData = "{\"registration_ids\":[\"id1\",\"id2\"],\"data\":{\"message\":\"Your message\",\"tickerText\":\"Your ticket\",\"contentTitle\":\"Your content\"}}";

        Console.WriteLine("Hello World!");

            client.PostAsync("https://localhost:44365/api/trades/", new StringContent(tradeStreamData))
                .ContinueWith(task =>
            {
                var responseNew = task.Result;
                Console.WriteLine(responseNew.Content.ReadAsStringAsync().Result);
            });


            Console.ReadKey();
        }
    }
}

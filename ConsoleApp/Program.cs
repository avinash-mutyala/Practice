using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Test
    {
        static async Task Main(string[] args)
        {
            var urls = new[] { "http://google.com", "http://www.pskills.org", "https://aws.amazon.com" };
            var httpClient = new HttpClient();
            foreach (var url in urls)
            {
                var response = await httpClient.GetAsync(url);
                Console.WriteLine($"{url} - {response.IsSuccessStatusCode}");
            }
        }

        static void Main()
        {
            //Prime.PrimeNumbers();
            //Ascii.MagicWord();

            Console.WriteLine();
        }






    }
}
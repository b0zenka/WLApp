using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WLApp
{
    class Program
    {
        const string URL = "https://wl-api.mf.gov.pl";
        const string GET = "/api/search/nip/{0}?date={1}";
        static void Main(string[] args)
        {
            ConsoleKey key;
            do
            {
                Console.Write("Podaj 10-cyfrowy NIP: ");
                string nip = Console.ReadLine();

                var subjects = GetByNIP(nip);

                if (subjects.Count() == 0)
                {
                    Console.WriteLine("Zły NIP");
                }
                else
                {
                    Console.WriteLine($"Konta powiązane z NIP: {nip}");
                    foreach (var subject in subjects)
                    {
                        Console.WriteLine(subject.ToString());
                    }
                }
                Console.WriteLine("=====================");

                Console.WriteLine("Naciśnij dowolny klawisz, aby spróbować raz jeszcze");
                Console.WriteLine("Naciśnij klawiasz 'Q' -  aby wyjść");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Q);

        }
        static IEnumerable<Subject> GetByNIP(string nip)
        {
            string date = string.Format("{0:0000}-{1:00}-{2:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            string get = string.Format(GET, nip, date);

            Root queryResult = ExecuteRestRequest<Root>(get, Method.GET);

            if (queryResult != null && queryResult.result != null && queryResult.result.subject != null)
                yield return queryResult.result.subject;
        }

        static T ExecuteRestRequest<T>(string get, Method method)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(get, method);
            return client.Execute<T>(request).Data;
        }

    }
}

using ClientWCF.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWCF
{
    class CNew
    {
        public string title;
        public DateTime data;
        public string textContent;
        public int refIdRest = 0;
    }
    class Program
    {
        private static long Benchmark(string endpointConfigurationName)
        {
            INewsService serviceClient = new NewsServiceClient(endpointConfigurationName);
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (var i = 0; i < 2000; i++)
            {
                serviceClient.Test();
            }

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }
        static void Main(string[] args)
        {
            LibNews kek = new LibNews();
            kek.Title = "Новая Новость";
            kek.ReleaseDate = DateTime.Now;
            kek.TextContent = "Очень интересное описание новости";

            int? proxyPort = 8000; // 18000;
            if (proxyPort.HasValue)            
            {
                // mitmweb --web-port 28000 --listen-port 18000 --mode reverse:http://localhost:13044
                var kk = new NewsServiceClient("BasicHttpBinding_INewsService",
                    $"http://localhost:{proxyPort.Value}/INewService");
                var ar = kk.SelectAllCategory();
                foreach( var item in ar)
                {
                    Console.WriteLine(item.NameCat);
                }
                kk.CreateNewWithCat(kek,new string[] { "Актуально сейчас","Актуально всегда"});           
                Console.WriteLine("Querying through proxy has been completed");
            }

            Console.ReadLine();
        }
    }
}

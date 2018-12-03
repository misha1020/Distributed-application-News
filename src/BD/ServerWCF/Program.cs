using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using NewsServiceLibrary;

namespace ServerWCF
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior
            {
                HttpGetEnabled = true,
                MetadataExporter = { PolicyVersion = PolicyVersion.Policy15 }
            };
            var host = new ServiceHost(typeof(NewsService), new Uri("http://localhost:13044/our/service"));
            host.Description.Behaviors.Add(behavior);
            host.AddServiceEndpoint(typeof(INewsService), new BasicHttpBinding(), "basic");
            host.Open();
            Console.WriteLine("Server is running");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//http://opendata.permkrai.ru/opendata/list.csv
namespace NewsServer
{
    class Program
    {
        static RabbitMQServer mq;
        static void Main(string[] args)
        {
            using (mq = new RabbitMQServer("localhost"))
            using (NewsReader reader = new NewsReader())
            {
                mq.MessageSend += Pr;
                reader.NewsReceived += NewNewsReceived;

                Console.ReadKey();
            }

        }

        private static void NewNewsReceived(string input)
        {
            try
            {
                mq.Send(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            input = Console.ReadLine();
        }

        static public void Pr(string message)
        {
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}

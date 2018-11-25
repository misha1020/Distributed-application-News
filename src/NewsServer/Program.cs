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
            using (mq = new RabbitMQServer("25.46.156.10"))
            using (WebhoseReader reader = new WebhoseReader())
            {
                mq.MessageSend += Pr;
                reader.NewsReceived += NewNewsReceived;
                reader.Start();
                Console.WriteLine("Write 'Q' to finish");
                string input = Console.ReadLine();
                while(input.ToUpper()!="Q")
                {
                    if(input.ToUpper()=="GET")
                    {
                        reader.GetNews();
                    }
                    if (input.ToUpper() == "GETALL")
                    {
                        reader.GetAllNews();
                    }
                    input = Console.ReadLine();
                }
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
            
        }

        static public void Pr(string message)
        {
            ;// Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}

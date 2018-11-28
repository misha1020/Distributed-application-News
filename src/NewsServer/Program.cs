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
            MessageToSend msg = new MessageToSend("127.0.0.1", "test", "test");
            using (mq = new RabbitMQServer(msg.hostIP, msg.login, msg.password))
            using (WebhoseReader reader = new WebhoseReader())
            {
				SocketServer.SocketSend(msg);
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
            //Console.WriteLine(" Sent {0}", message);
        }
    }
}

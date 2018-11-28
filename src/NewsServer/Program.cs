using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
//http://opendata.permkrai.ru/opendata/list.csv
namespace NewsServer
{
    class Program
    {
        static RabbitMQServer mq;
         static string dispatcherIp = ConfigManager.Get("dispatcherIp");
         static string rabbitMqIp = ConfigManager.Get("rabbitMqIp");
         static string username = ConfigManager.Get("username");
         static string password = ConfigManager.Get("password");
         static void Main(string[] args)
        {
            Thread pingReplier = new Thread(new ThreadStart(SocketServer.pingReply));
            pingReplier.Start();
            //Console.ReadKey();
            MessageToSend msg = new MessageToSend(rabbitMqIp, username, password);
            using (mq = new RabbitMQServer(msg.hostIP, msg.login, msg.password))
            using (WebhoseReader reader = new WebhoseReader())
            {
				SocketServer.SocketSend(msg, dispatcherIp);
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

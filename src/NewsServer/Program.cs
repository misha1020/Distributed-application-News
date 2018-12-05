using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MessageSendServe;

//http://opendata.permkrai.ru/opendata/list.csv

namespace NewsServer
{
    class Program
    {
        static RabbitMQServer mq;
        static string dispatcherIp = ConfigManager.Get("dispatcherIp");
        static string rabbitMqIp = ConfigManager.Get("rabbitMqIp");
        static string rabbitMqName = ConfigManager.Get("rabbitMqName");
        static string username = ConfigManager.Get("username");
        static string password = ConfigManager.Get("password");

        static void Main(string[] args)
        {
            var pingReply_cts = new CancellationToken();
            Task.Run(() => SocketServer.pingReply(pingReply_cts));

            MessageSendRecieve msg = new MessageSendRecieve(null, rabbitMqIp, rabbitMqName, username, password);
            try
            {
                using (mq = new RabbitMQServer(""/*msg.mqIP*/, msg.mqName, msg.login, msg.password))
                using (WebhoseReader reader = new WebhoseReader())
                {
                    SocketServer.SocketSend(msg, dispatcherIp);
                    mq.MessageSend += Pr;
                    reader.NewsReceived += NewNewsReceived;
                    reader.Start();
                    Console.WriteLine("Write \"Exit\" to finish");
                    string input = Console.ReadLine();
                    while (input.ToUpper() != "EXIT")
                    {
                        if (input.ToUpper() == "GET")
                        {
                            reader.GetNews();
                        }
                        if (input.ToUpper() == "GETALL")
                        {
                            reader.GetAllNews();
                        }
                        if (input.ToUpper() == "GETSOME")
                        {
                            reader.GetSomeNews();
                        }
                        if (input.ToUpper() == "REG")
                        {
                            SocketServer.SocketSend(msg, dispatcherIp);
                        }
                        input = Console.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message + " in " + ex.TargetSite);
                Console.ReadKey();
            }
        }


        private static void NewNewsReceived(string input)
        {
            try
            {
                mq.Send($"{rabbitMqName}:  {input}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        static public void Pr(string message)
        {
            Console.WriteLine(" Sent {0}", message);
        }
    }
}

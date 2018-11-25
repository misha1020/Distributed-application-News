using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://opendata.permkrai.ru/opendata/list.csv
namespace NewsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageToSend msg = new MessageToSend("25.46.156.10", "username", "password");
            SocketServer.SocketSend(msg);

            using (RabbitMQServer mq = new RabbitMQServer())
            {
                mq.Start("25.46.156.10");
                mq.MessageSend += Pr;
                Console.WriteLine("Write 'Q' to finish");
                string input = Console.ReadLine();
                while (input.ToUpper() != "Q")
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
                Console.WriteLine("Stopping");
            }

        }

        static public void Pr(string message)
        {
            Console.WriteLine(" Sent {0}", message);
        }
    }
}

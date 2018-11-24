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
            using (RabbitMQServer mq = new RabbitMQServer())
            {
                mq.Start("localhost");
                mq.MessageSend += Pr;
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
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}

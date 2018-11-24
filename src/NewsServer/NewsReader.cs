using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace NewsServer
{
    class NewsReader:IDisposable
    {
        string url = @"http://opendata.permkrai.ru/opendata/list.csv";
        private HttpWebRequest request;
        private HttpWebResponse response;
        private Timer timer;
        private double timerInterval = 5000;

        public delegate void NewsReceivedHandler(string message);
        public event NewsReceivedHandler NewsReceived;

        public NewsReader()
        {
            request = (HttpWebRequest)WebRequest.Create(url);

            timer = new Timer(timerInterval);
            timer.Elapsed += GetNews;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void GetNews(object sender, ElapsedEventArgs e)
        {
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding(response.CharacterSet));

                    List<New> news = new List<New>();
                    string newsStr = "";
                    while (!sr.EndOfStream)
                    {
                        var _new = new New(sr.ReadLine());
                        news.Add(_new);
                        newsStr += "\n"+_new.header;
                    }

                    NewsReceived(newsStr);
                }
                else
                {

                }
                response.Close();
            }
            catch(InvalidOperationException)
            { }
        }

        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}

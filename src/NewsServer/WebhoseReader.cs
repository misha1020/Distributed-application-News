using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using webhoseio;

namespace NewsServer
{
    

    class WebhoseReader:IDisposable
    {
        public struct Article
        {
            public string title;
            public string text;
            public DateTime published;
        }


        string token = "6524a769-2af5-444c-b0ba-1dae3897f5d1";
        private Timer timer;
        private double timerInterval = TimeSpan.FromHours(1).TotalMilliseconds;

        public delegate void NewsReceivedHandler(string message);
        public event NewsReceivedHandler NewsReceived;

        public List<Article> Articles;

        public WebhoseReader()
        {
            Articles = new List<Article>();

            timer = new Timer(timerInterval);
            timer.Elapsed += GetNews;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Start()
        {
            timer.Start();
            GetNews(null, null);
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void GetAllNews()
        {
            foreach(var art in Articles)
            {
                NewsReceived(art.title);
            }
        }

        public void GetNews(object sender=null, ElapsedEventArgs e=null)
        {
            List<Article> newNews = new List<Article>();
            try
            {
                var client = new WebhoseClient(token: token);
                var queryParams = new Dictionary<string, string>();
                queryParams.Add("q", "language:russian");
                queryParams.Add("sort", "crawled"); 
                queryParams.Add("site", "ruposters.ru");
                 var output = client.QueryAsync("filterWebContent", queryParams);
                while (!output.IsCompleted) { }
                if (output.IsCompleted)
                {
                    DateTime latestArticle = DateTime.MinValue;
                    if (Articles.Count > 0)
                        latestArticle = Articles[0].published;

                    for(int i=0;i<output.Result["posts"].Count();i++)
                    {
                        var article = output.Result["posts"][i];
                            var _article = new Article()
                            {
                                published = article["published"].ToObject<DateTime>(),
                                title = article["title"].ToObject<string>(),
                                text = article["text"].ToObject<string>()

                            };
                        if (_article.published > latestArticle)
                        {
                            Articles.Add(_article);
                            newNews.Add(_article);
                        }
                        else
                            break;
                    }
                    
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                foreach (var article in newNews)
                {
                    /*Console.WriteLine(article.title);
                    Console.WriteLine(article.text);
                    Console.WriteLine(article.published);*/
                    NewsReceived(article.title);
                }
                Console.WriteLine(newNews.Count);
            }
        }

        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}

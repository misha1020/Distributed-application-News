using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Data;
using NewsAPI.Models;
using NewsAPI.Constants;
using NewsAPI;

namespace NewsServer
{
    class NewsAPIReader:INewsReader
    {
        string apiKey = "0a3d290866794fec80d604841a0cc97e";
        private Timer timer;
        private double timerInterval = TimeSpan.FromHours(1).TotalMilliseconds;
        
        //public delegate void NewsReceivedHandler(string message);
        public event NewsReceivedHandler NewsReceived;

        public List<NewsAPI.Models.Article> Articles;

        public NewsAPIReader()
        {
            Articles = new List<NewsAPI.Models.Article>();

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


        public void GetSomeNews()
        {
            for (int i = 0; i < ((Articles.Count < 5) ? Articles.Count : 4); i++)
                NewsReceived(new MessageSendServe.Article(Articles[i].Title, Articles[i].Description, Articles[i].PublishedAt.ToString()));
        }

        public void GetAllNews()
        {
            foreach (var art in Articles)
                NewsReceived(new MessageSendServe.Article(art.Title, art.Description, art.PublishedAt.ToString()));
        }

        public void GetNews(object sender=null, ElapsedEventArgs e=null)
        {
            List<NewsAPI.Models.Article> newNews = new List<NewsAPI.Models.Article>();
            try
            {
                var newsApiClient = new NewsApiClient(apiKey);

                var articlesResponse = newsApiClient.GetEverything(new EverythingRequest
                { 
                    Q = "all",
                    SortBy = SortBys.PublishedAt,
                    Language = Languages.RU,
                    From = DateTime.Now - TimeSpan.FromDays(1)
                });

                if (articlesResponse.Status == Statuses.Ok)
                {
                    DateTime latestArticle = DateTime.MinValue;
                    if (Articles.Count > 0 && Articles[0].PublishedAt.HasValue)
                        latestArticle = Articles[0].PublishedAt.Value;


                    foreach (var article in articlesResponse.Articles)
                    {
                        if (article.PublishedAt.HasValue && article.PublishedAt.Value > latestArticle)
                        {
                            Articles.Add(article);
                            newNews.Add(article);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(articlesResponse.Error.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                foreach(var art in newNews)
                {
                    /*Console.WriteLine(art.Title);
                    Console.WriteLine(article.Author);
                    Console.WriteLine(article.Description);
                    Console.WriteLine(article.Url);
                    Console.WriteLine(article.UrlToImage);
                    Console.WriteLine(article.PublishedAt);*/
                    NewsReceived(new MessageSendServe.Article(art.Title, art.Description, art.PublishedAt.ToString()));
                }
            }
        }

        public void Dispose()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}

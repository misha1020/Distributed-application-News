using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSendServe
{
    [Serializable]
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PublishedAt { get; set; }
        public Article()
        { }
        public Article(string title, string content, string publishedAt)
        {
            Title = title;
            Content = content;
            PublishedAt = publishedAt;
        }
    }
}

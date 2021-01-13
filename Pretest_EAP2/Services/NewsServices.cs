using Pretest_EAP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAP2.Services
{
    public class NewsServices : INewsServices
    {

        private NewsContext context = new NewsContext();

        public bool DeleteNews(string NewsId)
        {
            var news = context.GetNews.Find(NewsId);
            context.GetNews.Remove(news);
            var deleted = context.SaveChanges();
            return deleted > 0;
        }

        public bool PostNews(News news)
        {
            context.GetNews.Add(news);
            var posted = context.SaveChanges();
            return posted > 0;
        }
    }
}

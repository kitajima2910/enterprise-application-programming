using Pretest_EAP2WCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Pretest_EAP2WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private NewsContext context = new NewsContext();

        public bool DeleteNews(string newsId)
        {
            var news = context.GetNews.Find(newsId);
            context.GetNews.Remove(news);
            var deleted = context.SaveChanges();
            return deleted > 0;
        }

        public bool PostNews(News news)
        {
            context.GetNews.Add(news);
            var created = context.SaveChanges();
            return created > 0;
        }
    }
}

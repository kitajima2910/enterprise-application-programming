using HBNYAPI.Models;
using HBNYAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBNYAPI.Services
{
    public class NewsServices : INewsServices
    {

        private ApplicationContext context;

        public NewsServices(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> Create(News news)
        {
            await context.GetNews.AddAsync(news);
            var created = await context.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> Delete(string newsId)
        {
            var news = await Get(newsId);
            context.GetNews.Remove(news);
            var deleted = await context.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<News> Get(string newsId)
        {
            return await context.GetNews.SingleOrDefaultAsync(m => m.NewsId.Equals(newsId));
        }

        public async Task<List<News>> GetAll()
        {
            return await context.GetNews.ToListAsync();
        }

        public async Task<List<News>> GetAll(string keyword)
        {
            return await context.GetNews.Where(m => m.NewsTitle.Contains(keyword)).ToListAsync();
        }

        public async Task<bool> Update(News news)
        {
            context.GetNews.Update(news);
            var updated = await context.SaveChangesAsync();
            return updated > 0;
        }
    }
}

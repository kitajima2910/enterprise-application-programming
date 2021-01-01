using HBNYAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBNYAPI.Services
{
    public interface INewsServices
    {
        Task<List<News>> GetAll();
        Task<News> Get(string newsId);
        Task<bool> Create(News news);
        Task<bool> Update(News news);
        Task<bool> Delete(string newsId);
        Task<List<News>> GetAll(string keyword);
    }
}

using Pretest_EAP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pretest_EAP2.Services
{
    public interface INewsServices
    {
        bool PostNews(News news);
        bool DeleteNews(string NewsId);
    }
}

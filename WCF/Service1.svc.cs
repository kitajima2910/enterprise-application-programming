using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCF.Models;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private ApplicationContext context = new ApplicationContext();

        public bool DeleteMovie(int id)
        {
            var model = context.GetMovies.Find(id);
            context.GetMovies.Remove(model);
            var deleted = context.SaveChanges();
            return deleted > 0;
        }

        public List<Movie> GetMoviesList()
        {
            return context.GetMovies.ToList();
        }

        public bool PostMovie(Movie movie)
        {
            context.GetMovies.Add(movie);
            var posted = context.SaveChanges();
            return posted > 0;
        }
    }
}

using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class MovieServicesImpl : IMovieServices
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
            var created = context.SaveChanges();
            return created > 0;
        }
    }
}

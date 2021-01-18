using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMovieServices
    {
        bool PostMovie(Movie movie);
        List<Movie> GetMoviesList();
        bool DeleteMovie(int id);
    }
}

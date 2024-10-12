using ASI.Basecode.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IMovieRepository
    {
        public IEnumerable<Movie> ViewMovies();

        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        Movie GetMovieById(string id);
        void DeleteMovie(string movieId);
    }
}

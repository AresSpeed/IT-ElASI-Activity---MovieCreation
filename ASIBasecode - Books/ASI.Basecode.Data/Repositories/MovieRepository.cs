using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        //private readonly List<Book> _allBooks = new(); // Use a proper list name for consistency.

        // Get all books
        List<Movie> _sampleBookDB = new();
        private readonly AsiBasecodeDBContext _dbContext;

        public MovieRepository(AsiBasecodeDBContext dBContext, IUnitOfWork unitOfWork): base(unitOfWork) { 
            _dbContext = dBContext;
        }
        public IEnumerable<Movie> ViewMovies()
        {
            return _dbContext.Movies.ToList();
        }

        // Add a new book
        public void AddMovie(Movie movie)
        {
            this.GetDbSet<Movie>().Add(movie);   
            UnitOfWork.SaveChanges();
            
        }

        // Update an existing book
        public void UpdateMovie(Movie movie)
        {
            var existingMovie = _dbContext.Movies.Find(movie.Id);
        
            if (existingMovie != null)
            {

                existingMovie.Title = movie.Title;
                existingMovie.Director = movie.Director;
                existingMovie.Description = movie.Description;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.ImageUrl = movie.ImageUrl;

                _dbContext.SaveChanges();
            }
        }


        public void DeleteMovie(Movie movie)
        {
            if (movie != null) {
                _dbContext.Remove(movie);
                UnitOfWork.SaveChanges();
            }
            
        }


        public void DeleteMovie(string movieId)
        {
            var movie = GetMovieById(movieId);
            if (movie != null)
            {
                _dbContext.Remove(movie);
                UnitOfWork.SaveChanges();
            }
        }


        public Movie GetMovieById(string id)
        {
            return _dbContext.Movies.FirstOrDefault(b => b.Id == id);
        }
    }
}
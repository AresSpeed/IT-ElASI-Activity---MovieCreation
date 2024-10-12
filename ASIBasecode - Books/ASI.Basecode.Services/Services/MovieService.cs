using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System.Collections.Generic;
using System;
using System.IO;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    // Constructor
    public MovieService(IMovieRepository movieRepository)
    {
        this._movieRepository = movieRepository;
    }

    public (bool, IEnumerable<Movie>) GetMovies()
    {
        var movies = _movieRepository.ViewMovies();
        if (movies != null) { 
            return (true, movies);
        }
        else
        {
            return (false, null);
        }
    }

    public void AddMovie(Movie movie)
    {
        try
        {
            var newMovie = new Movie();
            newMovie.Title = movie.Title;
            newMovie.Director = movie.Director;
            newMovie.Description = movie.Description;
            newMovie.ReleaseDate = movie.ReleaseDate;
            newMovie.ImageUrl = movie.ImageUrl;
            _movieRepository.AddMovie(newMovie);

            
        }
        catch (Exception) {
            throw new InvalidDataException("error adding movies");
        }
        //if (book == null)
        //{
        //    throw new ArgumentNullException();
        //}
        //var newBook = new Book
        //{
        //    Id = Guid.NewGuid().ToString(),
        //    Title = book.Title,
        //    Description = book.Description,
        //    Author = book.Author
        //};
        //_bookRepository.AddBook(newBook);
    }

    public void UpdateMovie(Movie movie)
    {
        if (movie == null || string.IsNullOrEmpty(movie.Id))
        {
            throw new ArgumentNullException(nameof(movie));
        }

        var existingMovie = _movieRepository.GetMovieById(movie.Id);
        if (existingMovie == null)
        {
            throw new KeyNotFoundException("Movie not found.");
        }

        existingMovie.Title = movie.Title;
        existingMovie.Director = movie.Director;
        existingMovie.Description = movie.Description;
        existingMovie.ReleaseDate = movie.ReleaseDate;
        existingMovie.ImageUrl = movie.ImageUrl;


        _movieRepository.UpdateMovie(existingMovie);
    }

    public void DeleteMovie(string movieId)
    {
        if (string.IsNullOrEmpty(movieId))
        {
            throw new ArgumentNullException(nameof(movieId));
        }

        var movie = _movieRepository.GetMovieById(movieId);
        if (movie == null)
        {
            throw new KeyNotFoundException("Movie not found.");
        }

        _movieRepository.DeleteMovie(movieId);
    }

    public void DeleteMovie(Movie movie)
    {
        throw new NotImplementedException();
    }
}
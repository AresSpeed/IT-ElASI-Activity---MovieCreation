using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        // Constructor
        public MovieController(IMovieService movieService)
        {
            this._movieService = movieService;
        }

        public ActionResult Index()
        {
            (bool result, IEnumerable<Movie> movies) = _movieService.GetMovies();
            movies = movies ?? new List<Movie>();
            return View(movies);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            try
            {
                _movieService.AddMovie(movie);
                return RedirectToAction("Index", "Movie");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessag"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = Resources.Messages.Errors.ServerError;
            }
            return View();

            //if (!ModelState.IsValid)
            //{
            //    return View(book);
            //}

            //_bookService.AddBook(book);
            //return RedirectToAction("Index", "Book");
        }


        public IActionResult Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            (bool result, IEnumerable<Movie> movies) = _movieService.GetMovies();
            var movie = movies.FirstOrDefault(b => b.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }


        [HttpPost]
        public IActionResult Edit(Movie movie)
        {

            if (string.IsNullOrEmpty(movie.Title) || string.IsNullOrEmpty(movie.Director) || string.IsNullOrEmpty(movie.Description) || movie.ReleaseDate == DateTime.MinValue || string.IsNullOrEmpty(movie.ImageUrl))
            {
                ModelState.AddModelError(string.Empty, "All fields (Title, Director, Description, ReleaseDate, Images) must be filled.");
                return View(movie);
            }

            _movieService.UpdateMovie(movie);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            (bool result, IEnumerable<Movie> movies) = _movieService.GetMovies();
            var book = movies.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
           
            return View(book);
        }


        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(string id)
        {
            _movieService.DeleteMovie(id);
            return RedirectToAction("Index");
        }
    }

}

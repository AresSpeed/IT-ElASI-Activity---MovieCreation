using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASI.Basecode.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        //Constructor
        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }
        public IActionResult Index()
        {
            (bool result, IEnumerable<Book> books) = _bookService.GetBooks();
            if (result)
            {
                return View(books);
            }
            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var book = _bookService.GetBooks().Item2.ToList().FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return RedirectToAction("Index", "Book");
            }
            catch (InvalidDataException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {

            _bookService.EditBook(book);
            TempData["SuccessMessage"] = "Book Edited Successfully";
            return RedirectToAction("Index", "Book"); 
        }

        public IActionResult Delete(int id)
        {
            var book = _bookService.GetBooks().Item2.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _bookService.DeleteBook(book);
            }
            return RedirectToAction("Index", "Book");
        }
    }
}

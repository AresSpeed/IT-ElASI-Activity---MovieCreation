using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using ASI.Basecode.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace ASI.Basecode.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        //Constructor
        public BookService(IBookRepository bookRepository) 
        { 
            this._bookRepository = bookRepository;
        }

        public (bool, IEnumerable<Book>) GetBooks()
        {
            var books = _bookRepository.ViewBooks();
            if (books != null)
            {
                return (true, books);
            }
            return (false, null);   
        }

        public void AddBook(Book book)
        {
            try
            {
                var newBook = new Book();
                newBook.Title = book.Title;
                newBook.Description = book.Description;
                newBook.Author = book.Author;
                _bookRepository.AddBook(newBook);
            }
            catch (Exception)
            {
                throw new InvalidDataException("Error Adding Book.");
            }
            
        }

        public void EditBook(Book book)
        {
            _bookRepository.EditBook(book);
        }

        public void DeleteBook(Book book)
        {
            _bookRepository.DeleteBook(book);
        }
    }
}

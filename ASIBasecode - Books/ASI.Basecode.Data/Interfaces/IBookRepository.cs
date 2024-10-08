using ASI.Basecode.Data.Models;
using System.Collections.Generic;

namespace ASI.Basecode.Data.Interfaces
{
    public interface IBookRepository
    {
        public IEnumerable<Book> ViewBooks();

        void AddBook(Book book);
        void EditBook(Book book);
        void DeleteBook(Book book);

    }
}

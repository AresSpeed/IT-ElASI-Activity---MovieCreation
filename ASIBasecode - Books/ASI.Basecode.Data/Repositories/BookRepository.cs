using ASI.Basecode.Data.Interfaces;
using ASI.Basecode.Data.Models;
using Basecode.Data.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ASI.Basecode.Data.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        List<Book> _samepleBookDB = new();

        private readonly AsiBasecodeDBContext _dbContext;
        public BookRepository(AsiBasecodeDBContext dbContext, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> ViewBooks()
        {
            return _dbContext.Books.ToList();
        }

        /*public List<Book> viewbooks()
        {
            return _allbook;
        }*/

        public void AddBook(Book book)
        {
            this.GetDbSet<Book>().Add(book);
            UnitOfWork.SaveChanges();  
        }

        public void EditBook(Book book)
        {
            this.GetDbSet<Book>().Update(book);
            UnitOfWork.SaveChanges();
        }

        public void DeleteBook(Book book)
        {
            _dbContext.Books.Remove(book);
            UnitOfWork.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;

namespace ProjectAPI.Repository.IRepository
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBooks(int BookId);
        bool BookExists(string name);
        bool BookExists(int id);
        bool CreateBook(Book book);
        bool UpdateBook(Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}

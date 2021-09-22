//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using ProjectAPI.Models;

//namespace ProjectAPI.Repository.IRepository
//{
//    public class BookRepository : IBookRepository
//    {
//        private readonly BookStoresDBContext _db;
//        public BookRepository(BookStoresDBContext db)
//        {
//            _db = db;
//        }

//        public bool BookExists(string name)
//        {
//            bool value = _db.Books.Any(a => a.Title.ToLower().Trim() == name.ToLower().Trim());
//            return value;
//        }

//        public bool BookExists(int id)
//        {
//            return _db.Books.Any(a => a.BookId == id);
//        }

//        public bool CreateBook(Book book)
//        {
//            _db.Books.Add(book);
//            return Save();
//        }

//        public bool DeleteBook(Book book)
//        {
//            _db.Books.Remove(book);
//            return Save();
//        }

//        public ICollection<Book> GetBooks()
//        {
//            return _db.Books.OrderBy(a => a.PublishedDate).ToList();
//        }

//        public Book GetBooks(int BookId)
//        {
//            return _db.Books.FirstOrDefault(a => a.BookId == BookId);
//        }

//        public bool Save()
//        {
//            return _db.SaveChanges() >= 0 ? true : false;
//        }

//        public bool UpdateBook(Book book)
//        {
//            _db.Books.Update(book);
//            return Save();
//        }
//    }
//}

using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Repository.IRepository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookStoresDBContext _db;
        public AuthorRepository(BookStoresDBContext db)
        {
            _db = db;
        }

        public bool AuthorExists(string name)
        {
            bool value = _db.Authors.Any(a => a.FirstName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool AuthorExists(int id)
        {
            return _db.Authors.Any(a => a.AuthorId == id);
        }

        public bool CreateAuthor(Author author)
        {
            _db.Authors.Add(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _db.Authors.Remove(author);
            return Save();
        }

        public ICollection<Author> GetAuthors()
        {
            return _db.Authors.OrderBy(a => a.AuthorId).ToList();
        }

        public Author GetAuthors(int AuthorId)
        {
            return _db.Authors.FirstOrDefault(a => a.AuthorId == AuthorId);
        }

        public Author GetName(string FirstName)
        {
            return _db.Authors.FirstOrDefault(a => a.FirstName == FirstName);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateAuthor(Author author)
        {
            _db.Authors.Update(author);
            return Save();
        }

    }
}

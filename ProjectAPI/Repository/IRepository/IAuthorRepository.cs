using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectAPI.Models;

namespace ProjectAPI.Repository.IRepository
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author GetAuthors(int AuthorId);
        Author GetName(string FirstName);
        bool AuthorExists(string name);
        bool AuthorExists(int id);
        bool CreateAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool DeleteAuthor(Author author);
        bool Save();
    }
}

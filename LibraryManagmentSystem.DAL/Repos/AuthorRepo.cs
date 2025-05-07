using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.DAL.Repos
{
    public class AuthorRepo : IAuthorRepository
    {

        private readonly LibraryDBContext db;

        public AuthorRepo(LibraryDBContext _db)
        {
            db = _db;
        }

        Task<List<Author>> IAuthorRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Author?> IAuthorRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        
        Task IAuthorRepository.AddAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IAuthorRepository.UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IAuthorRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        
        

        
    }
}

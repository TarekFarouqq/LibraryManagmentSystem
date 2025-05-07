using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.DAL.Repos
{
    public class BookRepo : IBookRepository
    {

        private readonly LibraryDBContext db;

        public BookRepo(LibraryDBContext _db)
        {
            db = _db;
        }

        Task<List<Author>> IBookRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Author?> IBookRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBookRepository.AddAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IBookRepository.UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IBookRepository.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



    }
}

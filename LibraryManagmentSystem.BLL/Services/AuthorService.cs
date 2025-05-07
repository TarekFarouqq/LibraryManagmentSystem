using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.BLL.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository authorRepo;

        public AuthorService(IAuthorRepository _authorRepo)
        {
            authorRepo = _authorRepo;
        }

        Task<List<Author>> IAuthorService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Author?> IAuthorService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IAuthorService.AddAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IAuthorService.UpdateAsync(Author author)
        {
            throw new NotImplementedException();
        }

        Task IAuthorService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}

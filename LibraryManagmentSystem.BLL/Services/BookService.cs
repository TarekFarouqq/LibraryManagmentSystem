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
   public  class BookService : IBookService
    {

        private readonly IBookRepository bookRepo;

        public BookService(IBookRepository _bookRepo)
        {
            bookRepo = _bookRepo;
        }
        Task<List<Book>> IBookService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Book?> IBookService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IBookService.AddAsync(Book book)
        {
            throw new NotImplementedException();
        }

        
        Task IBookService.UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        Task IBookService.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }





      
    }
}

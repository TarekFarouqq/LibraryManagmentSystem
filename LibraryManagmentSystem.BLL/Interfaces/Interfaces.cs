using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.BLL.DTOs;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.Interfaces
{
   public class Interfaces
    {

        public interface IAuthorService
        {
            Task AddAsync(InsertAuthorDTO author);
            Task UpdateAsync(InsertAuthorDTO author);
            Task DeleteAsync(int id);
            Task<ReadAuthorDTO?> GetByIdAsync(int id);
            Task<List<ReadAuthorDTO>> GetAllAsync();

        }


        public interface IBookService
        {
            Task AddAsync(Book book);
            Task UpdateAsync(Book book);
            Task DeleteAsync(int id);
            Task<Book?> GetByIdAsync(int id);
            Task<List<Book>> GetAllAsync();

        }
    }
}

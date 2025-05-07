using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.Interfaces
{
   public class Interfaces
    {

        public interface IAuthorService
        {
            Task AddAsync(Author author);
            Task UpdateAsync(Author author);
            Task DeleteAsync(int id);
            Task<Author?> GetByIdAsync(int id);
            Task<List<Author>> GetAllAsync();

        }


        public interface IBookService
        {
            Task AddAsync(Author author);
            Task UpdateAsync(Author author);
            Task DeleteAsync(int id);
            Task<Author?> GetByIdAsync(int id);
            Task<List<Author>> GetAllAsync();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.DAL.Interfaces
{
       public class Interfaces
    {
        public interface IAuthorRepository
        {
            Task AddAsync(Author author);
            Task UpdateAsync(Author author);
            Task DeleteAsync(int id);
            Task<Author?> GetByIdAsync(int id);
            Task<List<Author>> GetAllAsync();
            
        }


        public interface IBookRepository
        {
            Task AddAsync(Author author);
            Task UpdateAsync(Author author);
            Task DeleteAsync(int id);
            Task<Author?> GetByIdAsync(int id);
            Task<List<Author>> GetAllAsync();

        }


    }
}

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
            Task AddAsync(Book book);
            Task UpdateAsync(Book book);
            Task DeleteAsync(int id);
            Task<Book?> GetByIdAsync(int id);
            Task<List<Book>> GetAllAsync();
            Task<List<Book>> GetFilteredAsync(int filter ,int pageNum);
            Task<int> GetTotalPagesAsync(int filter);

        }

        public interface ILibraryRepository
        {
            Task<Book?> GetBookById(int bookId);
            Task<BorrowTransaction?> GetActiveTransaction(int bookId);
            Task AddTransaction(BorrowTransaction transaction);
            Task UpdateBook(Book book);
            Task UpdateTransaction(BorrowTransaction transaction);
        }


    }
}

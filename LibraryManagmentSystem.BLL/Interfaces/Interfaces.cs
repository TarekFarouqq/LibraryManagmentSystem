using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.BLL.DTOs.AuthorDTOs;
using LibraryManagmentSystem.BLL.DTOs.BookDTOs;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.Interfaces
{
    public class Interfaces
    {

        public interface IAuthorService
        {
            Task AddAsync(InsertAuthorDTO author);
            Task UpdateAsync(UpdateAuthorDTO author);
            Task DeleteAsync(int id);
            Task<ReadAuthorDTO?> GetByIdAsync(int id);
            Task<List<ReadAuthorDTO>> GetAllAsync();

        }


        public interface IBookService
        {
            Task AddAsync(InsertBookDTO book);
            Task UpdateAsync(UpdateBookDTO book);
            Task DeleteAsync(int id);
            Task<ReadBookDTO?> GetByIdAsync(int id);
            Task<List<ReadBookDTO>> GetAllAsync();

            Task<List<ReadBookDTO>> GetFilteredAsync(int filter , int pageNum);

            Task<int> GetTotalPagesAsync(int filter);

        }

        public interface ILibraryService
        {
            Task BorrowBook(int bookId);
            Task ReturnBook(int bookId);
        }
    }
}



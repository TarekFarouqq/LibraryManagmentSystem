using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;
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

        async Task<List<Book>> IBookRepository.GetAllAsync()
        {
            return await db.Books
                .Include(a => a.Author)
                .Include(a => a.BorrowTransactions)
                .ToListAsync();
        }

        async Task<Book?> IBookRepository.GetByIdAsync(int id)
        {
            return await db.Books
                .Include(a => a.Author)
                .Include(a => a.BorrowTransactions)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        Task IBookRepository.AddAsync(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            db.Books.Add(book);
            return db.SaveChangesAsync();
        }

        Task IBookRepository.UpdateAsync(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            db.Entry(book).State = EntityState.Modified;
            return db.SaveChangesAsync();
        }

        async Task IBookRepository.DeleteAsync(int id)
        {
            var book = await ((IBookRepository)this).GetByIdAsync(id);
            if (book == null)
            {
                throw new KeyNotFoundException($"Book with ID {id} not found.");
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();
        }

        async Task<int> IBookRepository.GetTotalPagesAsync(int filter)
        {
            if (filter < 0 || filter > 2)
            {
                throw new ArgumentOutOfRangeException(nameof(filter), "Filter must be between 0 and 2.");
            }
            else if (filter == 0)
            {
                int totalCount = await db.Books
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .CountAsync();

                double totalPages = totalCount / 6.0;
                return (int)Math.Ceiling(totalPages);
            }
            else if (filter == 1)
            {
                int totalCount = await db.Books
                    .Where(b => b.IsAvailable)
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .CountAsync();

                double totalPages = totalCount / 6.0;
                return (int)Math.Ceiling(totalPages);
            }
            else
            {
                int totalCount = await db.Books
                    .Where(b => !b.IsAvailable)
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .CountAsync();

                double totalPages = totalCount / 6.0;
                return (int)Math.Ceiling(totalPages);
            }
        }
    

        async Task<List<Book>> IBookRepository.GetFilteredAsync(int filter, int pageNum)
        {
            if (filter < 0 || filter > 3)
            {
                throw new ArgumentOutOfRangeException(nameof(filter), "Filter must be between 0 and 3.");
            }
            else if (filter == 0)
            {
                return await db.Books
                    .Skip((pageNum - 1) * 6)
                    .Take(6)
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .ToListAsync();
            }
            else if (filter == 1)
            {
                return await db.Books
                    .Where(b => b.IsAvailable)
                    .Skip((pageNum - 1) * 6)
                    .Take(6)
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .ToListAsync();
            }
            else
            {
                return await db.Books
                    .Where(b => !b.IsAvailable)
                    .Skip((pageNum - 1) * 6)
                    .Take(6)
                    .Include(a => a.Author)
                    .Include(a => a.BorrowTransactions)
                    .ToListAsync();
            }
        }
    }
}

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
    public  class LibraryRepo : ILibraryRepository
    {
        private readonly LibraryDBContext db;

        public LibraryRepo(LibraryDBContext _db)
        {
            db = _db;
        }


        public async Task<Book?> GetBookById(int bookId)
        {
           return await db.Books.FindAsync(bookId);
        }
            

        public async Task<BorrowTransaction?> GetActiveTransaction(int bookId)
        {
             return await db.BorrowTransactions
                .FirstOrDefaultAsync(t => t.BookId == bookId && t.ReturnedDate == null);
        }
           

        public async Task AddTransaction(BorrowTransaction transaction)
        {
            db.BorrowTransactions.Add(transaction);
            await db.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task UpdateTransaction(BorrowTransaction transaction)
        {
            db.Entry(transaction).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
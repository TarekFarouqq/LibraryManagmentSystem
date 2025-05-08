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
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository libraryRepo;

        public LibraryService(ILibraryRepository _libraryRepo)
        {
            libraryRepo = _libraryRepo;
        }

        async Task ILibraryService.BorrowBook(int bookId)
        {
            if (bookId <= 0)
            {
                throw new ArgumentException("Invalid book ID.");
            }
            var book = await libraryRepo.GetBookById(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book not found.");
            }
            book.IsAvailable = false;

            await libraryRepo.UpdateBook(book);

            await libraryRepo.AddTransaction(new BorrowTransaction
            {
                BookId = bookId,
                BorrowedDate = DateTime.UtcNow
            });

        }

        async Task ILibraryService.ReturnBook(int bookId)
        {
            if (bookId <= 0)
            {
                throw new ArgumentException("Invalid book ID.");
            }

            var transaction = await libraryRepo.GetActiveTransaction(bookId);
            if (transaction == null)
            {
                throw new ArgumentException("No active transaction found for this book.");
            }

            var book = await libraryRepo.GetBookById(bookId);
            if (book == null)
            {
                throw new ArgumentException("Book not found.");
            }


            transaction.ReturnedDate = DateTime.UtcNow;
            book.IsAvailable = true;

            await libraryRepo.UpdateTransaction(transaction);
            await libraryRepo.UpdateBook(book);
        }
    }
}

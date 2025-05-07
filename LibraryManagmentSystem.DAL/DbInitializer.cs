using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.DAL
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDBContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any())
            {
                var authors = new[]
                {
                new Author
                {
                    FullName = "John Ronald Reuel Tolkien",
                    Email = "tolkien@example.com",
                    Website = "www.tolkien.com",
                    Bio = "Author of The Lord of the Rings"
                },
                new Author
                {
                    FullName = "Joanne Kathleen Rowling",
                    Email = "rowling@example.com",
                    Website = "www.jkrowling.com",
                    Bio = "Author of Harry Potter series"
                }
            };

                context.Authors.AddRange(authors);
                context.SaveChanges();

                var books = new[]
                {
                new Book
                {
                    Title = "The Fellowship of the Ring",
                    Genre = BookGenre.Fantasy,
                    AuthorId = authors[0].Id
                },
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Genre = BookGenre.Fantasy,
                    AuthorId = authors[1].Id
                },
                new Book
                {
                    Title = " Second Book",
                    Genre = BookGenre.Fantasy,
                    AuthorId = authors[1].Id
                }
            };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}

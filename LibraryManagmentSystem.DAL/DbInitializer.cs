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
        FullName = "John Ronald ",
        Email = "tolkien@example.com",
        Website = "www.tolkien.com",
        Bio = "Author of The Lord of the Rings"
    },
    new Author
    {
        FullName = "Joanne Kathleen",
        Email = "rowling@example.com",
        Website = "www.jkrowling.com",
        Bio = "Author of Harry Potter series"
    },
    new Author
    {
        FullName = "George Orwell",
        Email = "orwell@example.com",
        Website = "www.georgeorwell.org",
        Bio = "English novelist and essayist"
    },
    new Author
    {
        FullName = "Agatha Christie",
        Email = "christie@example.com",
        Website = "www.agathachristie.com",
        Bio = "Queen of Crime fiction"
    },
    new Author
    {
        FullName = "Ernest Hemingway",
        Email = "hemingway@example.com",
        Website = "www.hemingwaybooks.com",
        Bio = "Nobel Prize-winning novelist"
    },
    new Author
    {
        FullName = "Jane Austen",
        Email = "austen@example.com",
        Website = "www.janeausten.co.uk",
        Bio = "English Romantic novelist"
    },
    new Author
    {
        FullName = "Mark Twain",
        Email = "twain@example.com",
        Website = "www.marktwainmuseum.org",
        Bio = "American humorist and writer"
    },
    new Author
    {
        FullName = "Mary Shelley",
        Email = "shelley@example.com",
        Website = "www.maryshelley.nl",
        Bio = "Author of Frankenstein"
    },
    new Author
    {
        FullName = "Leo Tolstoy",
        Email = "tolstoy@example.com",
        Website = "www.tolstoy.ru",
        Bio = "Russian literary master"
    },
    new Author
    {
        FullName = "Stephen King",
        Email = "king@example.com",
        Website = "www.stephenking.com",
        Bio = "Master of horror fiction"
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
                    AuthorId = authors[0].Id,
                    Description = "First volume of The Lord of the Rings trilogy following Frodo's quest"
                },
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Genre = BookGenre.Fantasy,
                    AuthorId = authors[1].Id,
                    Description = "First book in the Harry Potter series about a young wizard's discovery"
                },
                new Book
                {
                    Title = "1984",
                    Genre = BookGenre.SciFi,
                    AuthorId = authors[2].Id,
                    Description = "Dystopian novel exploring mass surveillance and totalitarianism"
                },
                new Book
                {
                    Title = "Murder on the Orient Express",
                    Genre = BookGenre.Mystery,
                    AuthorId = authors[3].Id,
                    Description = "Hercule Poirot solves a murder aboard a stranded luxury train"
                },
                new Book
                {
                    Title = "The Old Man and the Sea",
                    Genre = BookGenre.Adventure,
                    AuthorId = authors[4].Id,
                    Description = "Story of an aging fisherman's struggle with a giant marlin"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Genre = BookGenre.Romance,
                    AuthorId = authors[5].Id,
                    Description = "Classic novel of manners and marriage in Regency England"
                },
                new Book
                {
                    Title = "The Adventures of Huckleberry Finn",
                    Genre = BookGenre.Adventure,
                    AuthorId = authors[6].Id,
                    Description = "Journey of a boy and escaped slave down the Mississippi River"
                },
                new Book
                {
                    Title = "Frankenstein",
                    Genre = BookGenre.Biography,
                    AuthorId = authors[7].Id,
                    Description = "Gothic tale of scientific ambition creating a monstrous creature"
                },
                new Book
                {
                    Title = "War and Peace",
                    Genre = BookGenre.History,
                    AuthorId = authors[8].Id,
                    Description = "Epic novel chronicling French invasion of Russia"
                },
                new Book
                {
                    Title = "The Shining",
                    Genre = BookGenre.NonFiction,
                    AuthorId = authors[9].Id,
                    Description = "Haunting story of a family trapped in a haunted hotel"
                },
                
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Genre = BookGenre.Fantasy,
                    AuthorId = authors[5].Id,
                    Description = "First book in the Harry Potter series about a young wizard's discovery"
                },
                new Book
                {
                    Title = "1984",
                    Genre = BookGenre.SciFi,
                    AuthorId = authors[7].Id,
                    Description = "Dystopian novel exploring mass surveillance and totalitarianism"
                },
                new Book
                {
                    Title = "Murder on the Orient Express",
                    Genre = BookGenre.Mystery,
                    AuthorId = authors[2].Id,
                    Description = "Hercule Poirot solves a murder aboard a stranded luxury train"
                },
                new Book
                {
                    Title = "The Old Man and the Sea",
                    Genre = BookGenre.Adventure,
                    AuthorId = authors[1].Id,
                    Description = "Story of an aging fisherman's struggle with a giant marlin"
                },
                new Book
                {
                    Title = "Pride and Prejudice",
                    Genre = BookGenre.Romance,
                    AuthorId = authors[5].Id,
                    Description = "Classic novel of manners and marriage in Regency England"
                },
                new Book
                {
                    Title = "The Adventures of Huckleberry Finn",
                    Genre = BookGenre.Adventure,
                    AuthorId = authors[4].Id,
                    Description = "Journey of a boy and escaped slave down the Mississippi River"
                },
                new Book
                {
                    Title = "Frankenstein",
                    Genre = BookGenre.Biography,
                    AuthorId = authors[1].Id,
                    Description = "Gothic tale of scientific ambition creating a monstrous creature"
                },
                new Book
                {
                    Title = "War and Peace",
                    Genre = BookGenre.History,
                    AuthorId = authors[3].Id,
                    Description = "Epic novel chronicling French invasion of Russia"
                },
                new Book
                {
                    Title = "The Shining",
                    Genre = BookGenre.NonFiction,
                    AuthorId = authors[3].Id,
                    Description = "Haunting story of a family trapped in a haunted hotel"
                }
            };

                context.Books.AddRange(books);
                context.SaveChanges();
            }
        }
    }
}

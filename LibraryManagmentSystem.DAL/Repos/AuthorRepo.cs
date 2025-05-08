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
    public class AuthorRepo : IAuthorRepository
    {

        private readonly LibraryDBContext db;

        public AuthorRepo(LibraryDBContext _db)
        {
            db = _db;
        }

        async Task<List<Author>> IAuthorRepository.GetAllAsync()
        {
            return await db.Authors
                .AsNoTracking()
                .Include(a => a.Books)
                .ToListAsync();
        }

        async Task<Author?> IAuthorRepository.GetByIdAsync(int id)
        {
            return await db.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        Task IAuthorRepository.AddAsync(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            db.Authors.Add(author);
            return db.SaveChangesAsync();
        }

        Task IAuthorRepository.UpdateAsync(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            db.Entry(author).State = EntityState.Modified;
            return db.SaveChangesAsync();
        }

        async Task IAuthorRepository.DeleteAsync(int id)
        {
            var author = await ((IAuthorRepository)this).GetByIdAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} not found.");
            }

            db.Authors.Remove(author);
            await db.SaveChangesAsync(); 
        }
    }
}

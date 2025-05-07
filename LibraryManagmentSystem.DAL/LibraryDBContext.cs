using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagmentSystem.DAL
{
    public class LibraryDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowTransaction> BorrowTransactions { get; set; }

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasIndex(a => a.FullName)
                .IsUnique();

            modelBuilder.Entity<Author>()
                .HasIndex(a => a.Email)
                .IsUnique();
        }
    }
}

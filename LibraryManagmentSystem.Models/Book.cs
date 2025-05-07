using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

       
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }


        public ICollection<BorrowTransaction> BorrowTransactions { get; } = new List<BorrowTransaction>();
    }


    public enum BookGenre
    {
        Unknown, Adventure, Mystery,
        Thriller, Romance, SciFi, Fantasy, Biography, History, SelfHelp, Children, YoungAdult,
        Poetry, Drama, NonFiction
    }
}

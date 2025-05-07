using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.Models
{
   public  class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Website { get; set; }

        [MaxLength(300)]
        public string? Bio { get; set; }

        public ICollection<Book> Books { get; } = new List<Book>();
    }
}

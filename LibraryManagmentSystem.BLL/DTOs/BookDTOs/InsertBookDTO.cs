using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.DTOs.BookDTOs
{
    public class InsertBookDTO
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public int AuthorId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Web.ViewModels.BookVMs
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public BookGenre Genre { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }


    }
}

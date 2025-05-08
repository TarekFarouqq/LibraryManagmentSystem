using LibraryManagmentSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Web.ViewModels.BookVMs
{
    public class InsertBookViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(255)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        public BookGenre Genre { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
    }
}

using LibraryManagmentSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Web.ViewModels
{
    public class ReadAuthorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string? Bio { get; set; }
        public ICollection<Book> Books { get; } = new List<Book>();

    }
}

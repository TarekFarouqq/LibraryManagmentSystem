using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Web.ViewModels.AuthorVMs
{
    public class UpdateAuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Website { get; set; }

        [StringLength(300)]
        public string? Bio { get; set; }
    }
}

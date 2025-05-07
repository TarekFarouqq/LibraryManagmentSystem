using System.ComponentModel.DataAnnotations;

namespace LibraryManagmentSystem.Web.ViewModels
{
    public class InsertAuthorViewModel
    {


        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string? Website { get; set; }

        [MaxLength(300)]
        public string? Bio { get; set; }
    }
}

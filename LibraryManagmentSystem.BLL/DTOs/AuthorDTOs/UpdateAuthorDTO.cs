using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagmentSystem.BLL.DTOs.AuthorDTOs
{
    public class UpdateAuthorDTO
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

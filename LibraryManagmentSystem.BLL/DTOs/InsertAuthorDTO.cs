using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.DTOs
{
    public class InsertAuthorDTO
    {
        
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Website { get; set; }
        public string? Bio { get; set; }
        
    }
}

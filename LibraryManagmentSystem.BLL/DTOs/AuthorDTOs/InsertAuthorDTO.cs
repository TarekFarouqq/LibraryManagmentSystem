﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.DTOs.AuthorDTOs
{
    public class InsertAuthorDTO
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

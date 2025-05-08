using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.BLL.DTOs.BookDTOs
{
    public class ReadBookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BookGenre Genre { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }

        public bool IsAvailable { get; set; }
    }
}

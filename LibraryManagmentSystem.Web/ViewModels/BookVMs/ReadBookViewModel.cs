using LibraryManagmentSystem.Models;

namespace LibraryManagmentSystem.Web.ViewModels.BookVMs
{
    public class ReadBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BookGenre Genre { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }
        public bool IsAvailable { get; set; }

    }
}

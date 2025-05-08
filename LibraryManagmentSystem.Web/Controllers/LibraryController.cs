using AutoMapper;
using LibraryManagmentSystem.BLL.Services;
using LibraryManagmentSystem.Web.ViewModels.BookVMs;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.Web.Controllers
{
    public class LibraryController : Controller
    {
        private readonly IBookService bookService;
        private readonly ILibraryService libraryService;
        private readonly IMapper mapper;
        

        public LibraryController(IBookService _bookService, IMapper _mapper, ILibraryService _libraryService)
        {
            bookService = _bookService;
            mapper = _mapper;
            libraryService = _libraryService;

        }

        public async Task<IActionResult> Index(int filter = 0, int pageNum =1)
        {
            var bookDtos = await bookService.GetFilteredAsync(filter, pageNum);
            var booksVM = mapper.Map<List<ReadBookViewModel>>(bookDtos);
            var totalPages = await bookService.GetTotalPagesAsync(filter);

            ViewBag.Filter = filter;
            ViewBag.TotalPages = totalPages;
            return View(booksVM);
        }

        public async Task<IActionResult> BorrowDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid book ID.");
            }
            var bookDto = await bookService.GetByIdAsync(id);
            if (bookDto == null)
            {
                return NotFound("Book not found.");
            }
            var bookVM = mapper.Map<ReadBookViewModel>(bookDto);
            return View(bookVM);
        }

        public async Task<IActionResult> BorrowBook(int id)
        {
                if (id <= 0)
                {
                    return BadRequest("Invalid book ID.");
                }
                await libraryService.BorrowBook(id);
                var bookDtos = await bookService.GetFilteredAsync(0, 1);
                var booksVM = mapper.Map<List<ReadBookViewModel>>(bookDtos);
                var totalPages = await bookService.GetTotalPagesAsync(0);

                ViewBag.Filter = 0;
                ViewBag.TotalPages = totalPages;
                return View("Index", booksVM);  
        }

        public async Task<IActionResult> ReturnBook(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid book ID.");
            }
            await libraryService.ReturnBook(id);
            var bookDtos = await bookService.GetFilteredAsync(0, 1);
            var booksVM = mapper.Map<List<ReadBookViewModel>>(bookDtos);
            var totalPages = await bookService.GetTotalPagesAsync(0);

            ViewBag.Filter = 0;
            ViewBag.TotalPages = totalPages;
            return View("Index", booksVM);
        }
    }
}

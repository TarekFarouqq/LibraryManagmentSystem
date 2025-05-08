using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs.BookDTOs;
using LibraryManagmentSystem.BLL.Services;
using LibraryManagmentSystem.Models;
using LibraryManagmentSystem.Web.ViewModels.AuthorVMs;
using LibraryManagmentSystem.Web.ViewModels.BookVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;
        private readonly IAuthorService authorService;

        public BookController(IBookService _bookService, IMapper _mapper, IAuthorService _authorService)
        {
            bookService = _bookService;
            mapper = _mapper;
            authorService = _authorService;
        }

        public async Task<IActionResult> Index()
        {
            var bookDtos = await bookService.GetAllAsync();
            var booksVM = mapper.Map<List<ReadBookViewModel>>(bookDtos);
            return View(booksVM);
        }

        [HttpGet]
        public async Task<IActionResult> AddBook()
        {
            

            ViewBag.Genres = Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>().Select(g => new SelectListItem
                { Value = g.ToString(),Text = g.ToString()}).ToList();

            var authorDtos = await authorService.GetAllAsync();
            ViewBag.authorsList = mapper.Map<List<ReadAuthorViewModel>>(authorDtos);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(InsertBookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                var bookDto = mapper.Map<InsertBookDTO>(bookVM);
                await bookService.AddAsync(bookDto);
                return RedirectToAction("Index");
            }

            //list of genres
            ViewBag.Genres = Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>()
                .Select(g => new SelectListItem { Value = g.ToString(), Text = g.ToString() }).ToList();

            //list of authors
            var authorDtos = await authorService.GetAllAsync();
            ViewBag.authorsList = mapper.Map<List<ReadAuthorViewModel>>(authorDtos);

            return View(bookVM);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid request");

            var bookDto = await bookService.GetByIdAsync(id);
            if (bookDto == null)
                return NotFound();


            ViewBag.Genres = Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>().Select(g => new SelectListItem
            { Value = g.ToString(), Text = g.ToString() }).ToList();

            var authorDtos = await authorService.GetAllAsync();
            ViewBag.authorsList = mapper.Map<List<ReadAuthorViewModel>>(authorDtos);

            var bookVM = mapper.Map<UpdateBookViewModel>(bookDto);
            return View(bookVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateBookViewModel bookVM)
        {
            if (ModelState.IsValid)
            {
                var bookDto = mapper.Map<UpdateBookDTO>(bookVM);
                await bookService.UpdateAsync(bookDto);
                return RedirectToAction("Index");
            }


            ViewBag.Genres = Enum.GetValues(typeof(BookGenre)).Cast<BookGenre>().Select(g => new SelectListItem
            { Value = g.ToString(), Text = g.ToString() }).ToList();

            var authorDtos = await authorService.GetAllAsync();
            ViewBag.authorsList = mapper.Map<List<ReadAuthorViewModel>>(authorDtos);

            return View(bookVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid request");

            await bookService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

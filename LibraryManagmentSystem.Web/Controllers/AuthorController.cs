using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs.AuthorDTOs;
using LibraryManagmentSystem.Web.ViewModels.AuthorVMs;
using Microsoft.AspNetCore.Mvc;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService authorService;
        private readonly IMapper mapper;

        public AuthorController(IAuthorService _authorService,IMapper _mapper)
        {
            authorService = _authorService;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            var authorDtos = await authorService.GetAllAsync();

            var authorsVM = mapper.Map<List<ReadAuthorViewModel>>(authorDtos);
            return View(authorsVM);
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(InsertAuthorViewModel authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = mapper.Map<InsertAuthorDTO>(authorVM);
                await authorService.AddAsync(author);

                var authorsList = await authorService.GetAllAsync();
                return RedirectToAction("Index", authorsList);
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return BadRequest("Error");

            var authorDTO = await authorService.GetByIdAsync((int)id);
            var authorVM = mapper.Map<ReadAuthorViewModel>(authorDTO);
            if (authorVM == null)
                return NotFound();
            return View(authorVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
                return BadRequest("Error");

            var authorDTO = await authorService.GetByIdAsync((int)id);
            if (authorDTO == null)
                return NotFound();
            var authorVM = mapper.Map<UpdateAuthorViewModel>(authorDTO);
            return View(authorVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateAuthorViewModel author)
        {
            await authorService.UpdateAsync(mapper.Map<UpdateAuthorDTO>(author));
            var authorsList = await authorService.GetAllAsync();
            return RedirectToAction("Index", authorsList);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var authorDTO = await authorService.GetByIdAsync((int)id);
            await authorService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

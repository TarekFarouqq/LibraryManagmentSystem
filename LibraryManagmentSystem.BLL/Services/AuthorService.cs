using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs.AuthorDTOs;
using LibraryManagmentSystem.Models;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;



namespace LibraryManagmentSystem.BLL.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly IAuthorRepository authorRepo;
        private readonly IMapper mapper;

        public AuthorService(IAuthorRepository _authorRepo, IMapper _mapper)
        {
            authorRepo = _authorRepo;
            mapper = _mapper;
        }

        async Task<List<ReadAuthorDTO>> IAuthorService.GetAllAsync()
        {
            var authors = await authorRepo.GetAllAsync(); 
            return mapper.Map<List<ReadAuthorDTO>>(authors);
        }

        async Task<ReadAuthorDTO?> IAuthorService.GetByIdAsync(int id)
        {
            var author = await authorRepo.GetByIdAsync(id);
            if (author == null) return null;
            return mapper.Map<ReadAuthorDTO>(author);


        }

        async Task IAuthorService.AddAsync(InsertAuthorDTO newAuthor)
        {
            if (newAuthor == null)
            {
                throw new ArgumentException("Invalid author data.");
            }

            var authorEntity = mapper.Map<Author>(newAuthor);
            await authorRepo.AddAsync(authorEntity);
        }

        async Task IAuthorService.UpdateAsync(UpdateAuthorDTO author)
        {
            if (author == null)
            {
                throw new ArgumentException("Invalid author data.");
            }

            var authorEntity = mapper.Map<Author>(author);
            await authorRepo.UpdateAsync(authorEntity);
        }

        async Task IAuthorService.DeleteAsync(int id)
        {
            if (id <= 0) 
            {
                throw new ArgumentException("Invalid Author ID.");
            }
            await authorRepo.DeleteAsync(id); 
        }

       
    }
}

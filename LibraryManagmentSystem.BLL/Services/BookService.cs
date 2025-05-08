using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryManagmentSystem.BLL.DTOs.BookDTOs;
using LibraryManagmentSystem.Models;
using static LibraryManagmentSystem.BLL.Interfaces.Interfaces;
using static LibraryManagmentSystem.DAL.Interfaces.Interfaces;

namespace LibraryManagmentSystem.BLL.Services
{
   public  class BookService : IBookService
    {

        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepo, IMapper mapper)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
        }

        async Task<List<ReadBookDTO>> IBookService.GetAllAsync()
        {
            var books = await _bookRepo.GetAllAsync();
            return _mapper.Map<List<ReadBookDTO>>(books);
        }

        async Task<ReadBookDTO?> IBookService.GetByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            return book == null ? null : _mapper.Map<ReadBookDTO>(book);
        }

        async Task IBookService.AddAsync(InsertBookDTO newBook)
        {
            if (newBook == null)
            {
                throw new ArgumentException("Invalid book data.");
            }

            var bookEntity = _mapper.Map<Book>(newBook);
            await _bookRepo.AddAsync(bookEntity);
        }

        async Task IBookService.UpdateAsync(UpdateBookDTO book)
        {
            if (book == null)
            {
                throw new ArgumentException("Invalid book data.");
            }

            var bookEntity = _mapper.Map<Book>(book);
            await _bookRepo.UpdateAsync(bookEntity);
        }

        async Task IBookService.DeleteAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid Book ID.");
            }
            await _bookRepo.DeleteAsync(id);
        }


    }
}

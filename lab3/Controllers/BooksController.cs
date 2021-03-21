using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab3.Models;
using AutoMapper;
using lab3.Models.dto;
using lab3.Data;

namespace lab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksController(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> ListBooksAsync()
        {
            var res = await _booksRepository.ListBooksAsync();
            return Ok(_mapper.Map<List<BookDto>>(res));
        }

        [HttpGet("~/api/{id}/Books")]
        public async Task<ActionResult<BookDto>> GetBookAsync([FromRoute] Guid id)
        {
            var book = await _booksRepository.GetBookAsync(id);

            if (book == null)
                return NotFound();

            return Ok(_mapper.Map<BookDto>(book));
        }

        [HttpPut]
        public async Task<ActionResult> EditBookAsync(BookDto book)
        {
            if (book == null || string.IsNullOrEmpty(book.Title))
                return BadRequest();

            if (book.Id is not Guid id || !_booksRepository.BookExists(id))
                return NotFound();

            await _booksRepository.EditBookAsync(_mapper.Map<Book>(book));
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBookAsync(BookDto book)
        {
            if (book == null || string.IsNullOrEmpty(book.Title))
                return BadRequest();

            await _booksRepository.AddBookAsync(_mapper.Map<Book>(book));
            return Ok();
        }

        [HttpDelete("~/api/{id}/Books")]
        public async Task<IActionResult> RemoveBookAsync(Guid id)
        {
            if (!_booksRepository.BookExists(id))
                return NotFound();

            await _booksRepository.RemoveBookAsync(id);
            return Ok();
        }
    }
}

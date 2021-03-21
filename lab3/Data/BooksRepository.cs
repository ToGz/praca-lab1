using lab3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab3.Data
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public BooksRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public Task<List<Book>> ListBooksAsync()
        {
            return _dbcontext.Books.ToListAsync();
        }

        public Task<Book> GetBookAsync(Guid id)
        {
            return _dbcontext.Books.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task EditBookAsync(Book book)
        {
            _dbcontext.Entry(book).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
        }
        public async Task AddBookAsync(Book book)
        {
            _dbcontext.Books.Add(book);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task RemoveBookAsync(Guid id)
        {
            var book = await _dbcontext.Books.FindAsync(id);
            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();
        }

        public bool BookExists(Guid id)
        {
            return _dbcontext.Books.Any(e => e.Id == id);
        }
    }
}

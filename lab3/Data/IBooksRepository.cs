using lab3.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab3.Data
{
    public interface IBooksRepository
    {
        bool BookExists(Guid id);
        Task RemoveBookAsync(Guid id);
        Task<Book> GetBookAsync(Guid id);
        Task<List<Book>> ListBooksAsync();
        Task AddBookAsync(Book book);
        Task EditBookAsync(Book book);
    }
}
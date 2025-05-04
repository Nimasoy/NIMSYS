using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class BookRepository(LibraryDbContext context) : Repository<Book>(context), IBookRepository
    {
        public async Task<IEnumerable<Book>> GetMostBorrowedAsync(int count)
        {
            return await _context.Books
                .OrderByDescending(b => b.Lendings.Count)
                .Take(count)
                .ToListAsync();
        }
    }
} 
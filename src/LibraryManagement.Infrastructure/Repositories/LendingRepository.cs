using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class LendingRepository(LibraryDbContext context) : Repository<Lending>(context), ILendingRepository
    {
        public async Task<IEnumerable<Lending>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Lendings
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<int> GetActiveBorrowedCountByUserAsync(Guid userId)
        {
            return await _context.Lendings
                .CountAsync(l => l.UserId == userId && l.ReturnedAt == null);
        }

        public async Task<Lending?> GetActiveLendingAsync(Guid bookId, Guid userId)
        {
            return await _context.Lendings
                .FirstOrDefaultAsync(l => l.BookId == bookId && l.UserId == userId && l.ReturnedAt == null);
        }
    }
} 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Domain.Interfaces
{
    public interface ILendingRepository : IRepository<Lending>
    {
        Task<IEnumerable<Lending>> GetByUserIdAsync(Guid userId);
        Task<int> GetActiveBorrowedCountByUserAsync(Guid userId);
        Task<Lending?> GetActiveLendingAsync(Guid bookId, Guid userId);
    }
}
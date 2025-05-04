using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetMostBorrowedAsync(int count);
    }
}
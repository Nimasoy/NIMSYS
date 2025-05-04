using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class CategoryRepository(LibraryDbContext context) : Repository<Category>(context), ICategoryRepository
    {
    }
} 
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class TagRepository(LibraryDbContext context) : Repository<Tag>(context), ITagRepository
    {
    }
} 
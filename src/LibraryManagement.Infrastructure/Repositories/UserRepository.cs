using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class UserRepository(LibraryDbContext context) : Repository<User>(context), IUserRepository
    {
    }
} 
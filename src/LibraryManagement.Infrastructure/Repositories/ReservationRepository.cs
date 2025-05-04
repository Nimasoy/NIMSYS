using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Infrastructure.Data;

namespace LibraryManagement.Infrastructure.Repositories
{
    public class ReservationRepository(LibraryDbContext context) : Repository<Reservation>(context), IReservationRepository
    {
    }
} 
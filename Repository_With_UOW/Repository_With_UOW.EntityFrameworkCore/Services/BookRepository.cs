using Repository_With_UOW.Application.contracts.Interfaces;
using Repository_With_UOW.Application.contracts.Models;
using Repository_With_UOW.EntityFrameworkCore.Data;

namespace Repository_With_UOW.EntityFrameworkCore.Services;
public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly ApplicationDbContext _context;
    public BookRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public List<Book> GetAllBooksSpecialMethod()
    {
        throw new NotImplementedException();
    }
}

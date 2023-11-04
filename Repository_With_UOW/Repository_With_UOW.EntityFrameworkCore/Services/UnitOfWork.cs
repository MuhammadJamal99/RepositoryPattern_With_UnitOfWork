using Repository_With_UOW.Application.contracts.Interfaces;
using Repository_With_UOW.Application.contracts.Models;
using Repository_With_UOW.EntityFrameworkCore.Data;

namespace Repository_With_UOW.EntityFrameworkCore.Services;
public class UnitOfWork : IUnitOfWork
{
    public IBaseRepository<Author> AuthorRepository { get; private set; }

    public IBaseRepository<Book> BookRepository { get; private set; }

    private readonly ApplicationDbContext _context;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        AuthorRepository = new BaseRepository<Author>(_context);
        BookRepository = new BaseRepository<Book>(_context);
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

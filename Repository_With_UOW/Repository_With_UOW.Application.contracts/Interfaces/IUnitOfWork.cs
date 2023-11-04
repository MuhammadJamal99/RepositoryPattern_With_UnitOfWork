using Repository_With_UOW.Application.contracts.Models;

namespace Repository_With_UOW.Application.contracts.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IBaseRepository<Author> AuthorRepository { get; }
    IBaseRepository<Book> BookRepository { get; }
    int Complete();
}

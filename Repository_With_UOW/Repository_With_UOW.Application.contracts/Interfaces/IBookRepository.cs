using Repository_With_UOW.Application.contracts.Models;

namespace Repository_With_UOW.Application.contracts.Interfaces;
public interface IBookRepository : IBaseRepository<Book>
{
    List<Book> GetAllBooksSpecialMethod();
}

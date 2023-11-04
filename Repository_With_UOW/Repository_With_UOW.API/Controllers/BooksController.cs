using Repository_With_UOW.Application.contracts.Constants;
using Repository_With_UOW.Application.contracts.DTOS;

namespace Repository_With_UOW.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public BooksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetByID(Guid id)
    {
        return Ok(_unitOfWork.BookRepository.GetById(id));
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return Ok(await _unitOfWork.BookRepository?.GetByIdAsync(id));
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_unitOfWork.BookRepository.GetAll());
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _unitOfWork.BookRepository.GetAllAsync());
    }

    [HttpGet("GetByTitle")]
    public IActionResult GetByName(string title)
    {
        return Ok(_unitOfWork.BookRepository.Find(b => b.Title == title, new[] { "Author" }));
    }

    [HttpGet("GetAllByAuthorName")]
    public IActionResult GetAllByAuthorName(string authorName)
    {
        return Ok(_unitOfWork.BookRepository.FindAll(b => b.Author.Name == authorName, new[] { "Author" }));
    }

    [HttpGet("GetAllOrderedBy")]
    public IActionResult GetAllOrderedBy(string authorName)
    {
        return Ok(_unitOfWork.BookRepository.FindAll(b => b.Author.Name == authorName, null, null, new[] { "Author" }, b => b.Title, OrderBy.Descending));
    }

    [HttpPost("AddOne")]
    public IActionResult AddOne(CreateBookDto book)
    {
        Book entity = _unitOfWork.BookRepository.Add(new Book()
        {
            AuthorId = book.AuthorId,
            Title = book.Title,
            Id = book.Id,
            CreatedAt = DateTime.UtcNow
        });
        _unitOfWork.Complete();

        return Ok(entity);
    }

    [HttpPost("AddRange")]
    public IActionResult AddRange(List<CreateBookDto> bookDtos)
    {
        List<Book> books = bookDtos.Select(b => new Book()
        {
            Id = b.Id,
            AuthorId = b.AuthorId,
            Title = b.Title,
            CreatedAt = DateTime.UtcNow
        }).ToList();

        List<Book> entities = _unitOfWork.BookRepository.AddRange(books);

        _unitOfWork.Complete();

        return Ok(entities);
    }
}

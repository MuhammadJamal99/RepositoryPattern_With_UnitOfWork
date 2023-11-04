namespace Repository_With_UOW.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IBaseRepository<Author> _authorRepository;

    public AuthorsController(IBaseRepository<Author> authorRepository)
    {
        _authorRepository = authorRepository;
    }

    [HttpGet]
    public IActionResult GetByID(Guid id)
    {
        return Ok(_authorRepository.GetById(id));
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return Ok(await _authorRepository?.GetByIdAsync(id));
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_authorRepository.GetAll());
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _authorRepository.GetAllAsync());
    }

    [HttpGet("GetByName")]
    public IActionResult GetByName(string name)
    {
        return Ok(_authorRepository.Find(b => b.Name == name));
    }
}

namespace Repository_With_UOW.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthorsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public IActionResult GetByID(Guid id)
    {
        return Ok(_unitOfWork.AuthorRepository.GetById(id));
    }

    [HttpGet("GetByIdAsync")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        return Ok(await _unitOfWork.AuthorRepository.GetByIdAsync(id));
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        return Ok(_unitOfWork.AuthorRepository.GetAll());
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _unitOfWork.AuthorRepository.GetAllAsync());
    }

    [HttpGet("GetByName")]
    public IActionResult GetByName(string name)
    {
        return Ok(_unitOfWork.AuthorRepository.Find(b => b.Name == name));
    }
}

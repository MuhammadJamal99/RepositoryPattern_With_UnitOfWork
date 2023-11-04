namespace Repository_With_UOW.Application.contracts.DTOS;
public sealed class CreateBookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
}

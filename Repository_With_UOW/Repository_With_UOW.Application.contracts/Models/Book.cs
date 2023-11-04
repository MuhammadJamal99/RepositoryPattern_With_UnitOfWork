namespace Repository_With_UOW.Application.contracts.Models;
public class Book : BaseEntity
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}

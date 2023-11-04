using Microsoft.EntityFrameworkCore;

namespace Repository_With_UOW.EntityFrameworkCore.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}

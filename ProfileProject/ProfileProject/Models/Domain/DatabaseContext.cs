using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfileProject.Models.DTO;

namespace ProfileProject.Models.Domain;

public class DatabaseContext:IdentityDbContext<ApplicationUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }
    public DbSet<ApplicationUser> applicationUsers { get; set; }
   
}

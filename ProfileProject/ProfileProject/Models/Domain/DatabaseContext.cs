﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProfileProject.Models.Domain;

public class DatabaseContext:IdentityDbContext<ApplicationUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
        
    }
    public DbSet<ApplicationUser> applicationUsers { get; set; }
}

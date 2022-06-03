using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SchneiderHolzBlazorApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
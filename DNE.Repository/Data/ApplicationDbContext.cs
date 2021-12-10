using DNE.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DNE.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
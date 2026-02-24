using Microsoft.EntityFrameworkCore;
using EventManagement.Api.Models;

namespace EventManagement.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Event> Events => Set<Event>();
    }
}

using apiPost.Models;
using Microsoft.EntityFrameworkCore;

namespace apiPost{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {            
        }
        public DbSet<Post> Posts {get; set;}
    }
}
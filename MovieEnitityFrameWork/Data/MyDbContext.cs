using Microsoft.EntityFrameworkCore;
using MovieEnitityFrameWork.Models;

namespace MovieEnitityFrameWork.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}

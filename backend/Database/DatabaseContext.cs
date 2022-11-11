using APIBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace APIBackend.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions <DatabaseContext> options):base(options)
        {

        }
        public DbSet<Enterprise> Enterprises { get; set; }
    }
}

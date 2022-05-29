using Microsoft.EntityFrameworkCore;
using ULTIMATE_API.Models;

namespace ULTIMATE_API.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
        : base(options)
        {
        }

        // repersents the table Companies
        public DbSet<Company> Companies { get; set; }
        // repersents the table Employees
        public DbSet<Employee> Employees { get; set; }
    }

}

using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<EmployeeModel> Employees { get; set; }


    }
}
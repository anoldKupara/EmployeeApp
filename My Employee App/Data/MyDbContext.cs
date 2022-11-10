using Microsoft.EntityFrameworkCore;
using My_Employee_App.Entities;

namespace My_Employee_App.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}

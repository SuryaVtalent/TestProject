using Microsoft.EntityFrameworkCore;
using WebAPIFProject.Models;

namespace WebAPIFProject.DBContext
{
    public class DBContextt:DbContext
    {
        public DBContextt(DbContextOptions<DBContextt>options):base(options) { }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }

    }
}

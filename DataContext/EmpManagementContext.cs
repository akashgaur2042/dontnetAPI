using API.EmployeeModel;
using API.UserModel;
using Microsoft.EntityFrameworkCore;

namespace API.DataContext
{
    public class EmpManagementContext : DbContext
    {
        public EmpManagementContext(DbContextOptions<EmpManagementContext> options) : base(options)
        {
        }
        public DbSet<User> User {get;set;}
        public DbSet<Employee> Employee {get;set;}        
    }


}
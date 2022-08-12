using Microsoft.EntityFrameworkCore;

namespace ApiWebBlog.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=WIN-V45TJ7IL2H4; database=WebBlogApiDB;  integrated security=true;"); ;
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

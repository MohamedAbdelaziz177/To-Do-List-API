using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ToDoListApi.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

           
            optionsBuilder.
                UseMySql("Data Source=localhost;Initial Catalog=ToDoDb;user=root;password=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.1.0-mysql"));
        }

        public DbSet<ToDo> toDos {  get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using toDoList.Models;

namespace toDoList.Data
{
    public class ApplictionDbContext : DbContext
        
    {
        public DbSet<Models.Task> tasks  { get; set; }
        public DbSet<Save> saves { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Task;Integrated Security=True;" +
                "TrustServerCertificate=True");
        }
    }
}

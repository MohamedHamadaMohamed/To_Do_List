using Microsoft.EntityFrameworkCore;
using To_Do_List.Models;

namespace To_Do_List.Data
{
    public class AppliactionDbContext : DbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=To_Do_List;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoList>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ToDoList>()
                .Property(e => e.Title)
                .HasColumnType("varchar(30)");

            modelBuilder.Entity<ToDoList>()
                .Property(e => e.Description)
                .HasColumnType("varchar(50)");
        }


    }
}

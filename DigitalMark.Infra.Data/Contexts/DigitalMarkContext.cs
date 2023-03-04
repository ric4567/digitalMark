using Biblioteca.Livro.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DigitalMark.Contexts
{
    public class DigitalMarkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=postgres;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
        }
    }
}

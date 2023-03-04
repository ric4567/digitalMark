using Biblioteca.Livro.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Biblioteca.Livro.Infra.Data.Contexts
{
    public class DigitalMarkContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Data Source=JUPITER;Initial Catalog=Teste_Ricardo;Persist Security Info=True;User ID=developers;password=8UImoZhM;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
        }
    }
}

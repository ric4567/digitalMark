using DigitalMark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Livro.Infra.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.Notifications);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
        }
    }
}
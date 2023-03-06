using DigitalMark.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biblioteca.Livro.Infra.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.IsValid);
            builder.Ignore(x => x.Notifications);
            builder.Property(x => x.Id);
            builder.Property(x => x.Name);
            builder.Property(x => x.Technology);
            builder.HasOne(x => x.Project)
                .WithOne(x => x.Client)
                .HasForeignKey<Client>(x => x.ProjectId);
        }
    }
}
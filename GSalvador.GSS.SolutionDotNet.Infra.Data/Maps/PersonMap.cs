using GSalvador.GSS.SolutionDotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GSalvador.GSS.SolutionDotNet.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("cliente");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("id_cliente")
            .UseIdentityColumn();

        builder.Property(x => x.Name)
            .HasColumnName("nome");

        builder.Property(x => x.Document)
            .HasColumnName("documento");

        builder.Property(x => x.Phone)
            .HasColumnName("contato");

        builder.HasMany(x => x.Purchases)
            .WithOne(x => x.Person)
            .HasForeignKey(x => x.PersonId);
    }
}

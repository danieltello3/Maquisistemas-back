using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class ClientConfiguration : IEntityTypeConfiguration<Client>
{
	public void Configure(EntityTypeBuilder<Client> builder)
	{
		builder.ToTable("Clients");
		builder.HasKey(client => client.Id);
		builder.Property(client => client.Nombres).HasMaxLength(100).IsRequired();
		builder.Property(client => client.Apellidos).HasMaxLength(100).IsRequired();
		builder.Property(client => client.FechaNacimiento).IsRequired();
		builder.Property(client => client.IdTipoDocumento).IsRequired();
		builder.Property(client => client.NroDocumento).HasMaxLength(20).IsRequired();
		builder.Property(client => client.Estado);
	}
}


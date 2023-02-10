using Domain.Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DocumentConfiguration : IEntityTypeConfiguration<Document>
{
	public void Configure(EntityTypeBuilder<Document> builder)
	{
		builder.Property(d => d.Code).HasMaxLength(100).IsRequired();
		builder.Property(d => d.Title).HasMaxLength(500).IsRequired();

		builder.OwnsOne(b => b.CategoryColor);
	}
}
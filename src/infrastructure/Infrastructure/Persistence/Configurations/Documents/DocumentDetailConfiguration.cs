using Domain.Documents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Documents;

public class DocumentDetailConfiguration : IEntityTypeConfiguration<DocumentDetail>
{
	public void Configure(EntityTypeBuilder<DocumentDetail> builder)
	{
		builder.Property(dd => dd.Text).HasMaxLength(200).IsRequired();
	}
}

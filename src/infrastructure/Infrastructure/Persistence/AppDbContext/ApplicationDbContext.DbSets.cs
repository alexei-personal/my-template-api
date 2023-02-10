using Domain.Base;
using Domain.Documents.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.AppDbContext;

public partial class ApplicationDbContext
{
	public DbSet<TempId> TempId => Set<TempId>();

	public DbSet<Document> Document => Set<Document>();

	public DbSet<DocumentDetail> DocumentDetail => Set<DocumentDetail>();

}

using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;


using Application.Common.Interfaces;
using Common.Services.Time;
using Domain.Base;
using Infrastructure.Extensions;

namespace Infrastructure.Persistence.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
	private readonly ICurrentUserService _currentUserService;
	private readonly ITimeService _timeService;

	public AuditableEntitySaveChangesInterceptor(
		ICurrentUserService currentUserService,
		ITimeService timeService)
	{
		_currentUserService = currentUserService;
		_timeService = timeService;
	}

	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		UpdateEntities(eventData.Context);

		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken ct = default)
	{
		UpdateEntities(eventData.Context);

		return base.SavingChangesAsync(eventData, result, ct);
	}

	public void UpdateEntities(DbContext? context)
	{
		if (context == null) return;

		foreach (var entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedBy = _currentUserService.UserId;
				entry.Entity.Created = _timeService.GetUtcTime();
			}

			if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.HasChangedOwnedEntities())
			{
				entry.Entity.LastModifiedBy = _currentUserService.UserId;
				entry.Entity.LastModified = _timeService.GetUtcTime();
			}
		}
	}
}

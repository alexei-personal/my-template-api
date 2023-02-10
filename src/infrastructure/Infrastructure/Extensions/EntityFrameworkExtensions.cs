using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Reflection;

namespace Infrastructure.Extensions;

internal static class EntityFrameworkExtensions
{
	public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
		entry.References.Any(r =>
			r.TargetEntry != null &&
			r.TargetEntry.Metadata.IsOwned() &&
			(r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));

	public static IQueryable NonGenericSet(this DbContext context, Type entityType)
	{
		// get generic DbSet method info
		var method = typeof(DbContext)
			.GetMethods()
			.FirstOrDefault(m => m.Name == "Set" && m.ContainsGenericParameters);
		if (method == null)
			throw new ArgumentException($"Failed to get generic type definition for set of type {entityType.Name}");

		method = method.MakeGenericMethod(entityType);
		if (method == null) 
			throw new ArgumentException($"Failed to create generic method for type {entityType.Name}");

		if (method.Invoke(context, null) is not IQueryable ret)
			throw new ArgumentException($"Failed to convert Set invocation to IQueryable for type {entityType.Name}");

		return ret;
	}

	//TODO: try with suggestion done during the review done by ChatGPT:
	//public static IQueryable NonGenericSet(this DbContext context, Type entityType)
	//{
	//	MethodInfo method = typeof(DbContext).GetMethod("Set");
	//	if (method == null)
	//	{
	//		throw new ArgumentException($"The method 'Set' was not found in the DbContext type.");
	//	}

	//	method = method.MakeGenericMethod(entityType);
	//	object set = method.Invoke(context, null);
	//	if (set == null)
	//	{
	//		throw new ArgumentException($"The method invocation of 'Set' for type '{entityType.Name}' returned null.");
	//	}

	//	IQueryable ret = set as IQueryable;
	//	if (ret == null)
	//	{
	//		throw new ArgumentException($"The result of the method invocation of 'Set' for type '{entityType.Name}' could not be converted to IQueryable.");
	//	}

	//	return ret;
	//}
}

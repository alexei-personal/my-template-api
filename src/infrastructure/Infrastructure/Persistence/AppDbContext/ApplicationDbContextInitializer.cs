﻿using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.AppDbContext;

/// seed data in the database
public class ApplicationDbContextInitializer
{
	private readonly ILogger<ApplicationDbContextInitializer> _logger;
	private readonly ApplicationDbContext _context;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly RoleManager<IdentityRole> _roleManager;

	public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
	{
		_logger = logger;
		_context = context;
		_userManager = userManager;
		_roleManager = roleManager;
	}

	public async Task InitialiseAsync()
	{
		try
		{
			if (_context.Database.IsSqlServer())
			{
				await _context.Database.MigrateAsync();
			}
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while initialising the database.");
			throw;
		}
	}

	public async Task SeedAsync()
	{
		try
		{
			await TrySeedAsync();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, "An error occurred while seeding the database.");
			throw;
		}
	}

	/// <summary>
	/// seed more dynamic information here
	/// </summary>
	/// <returns></returns>
	public async Task TrySeedAsync()
	{
		var administratorRole = await SeedDefaultRoles();

		await SeedDefaultUsers(administratorRole);
	}

	private async Task SeedDefaultUsers(IdentityRole administratorRole)
	{
		var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

		if (_userManager.Users.All(u => u.UserName != administrator.UserName))
		{
			await _userManager.CreateAsync(administrator, "Administrator1!");
			if (!string.IsNullOrWhiteSpace(administratorRole.Name))
			{
				await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
			}
		}
	}

	private async Task<IdentityRole> SeedDefaultRoles()
	{
		var administratorRole = new IdentityRole("Administrator");

		if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
		{
			await _roleManager.CreateAsync(administratorRole);
		}

		return administratorRole;
	}
}

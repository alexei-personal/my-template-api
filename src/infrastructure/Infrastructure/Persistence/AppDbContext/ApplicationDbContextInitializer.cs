//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;

//namespace Infrastructure.Persistence.AppDbContext;

//TODO: remove
///// seed data in the database
//public class ApplicationDbContextInitializer
//{
//	private readonly ILogger<ApplicationDbContextInitializer> _logger;
//	private readonly ApplicationDbContext _context;

//	public ApplicationDbContextInitializer(
//		ILogger<ApplicationDbContextInitializer> logger, 
//		ApplicationDbContext context)
//	{
//		_logger = logger;
//		_context = context;
//	}

//	public async Task InitialiseAsync()
//	{
//		try
//		{
//			if (_context.Database.IsSqlServer())
//			{
//				await _context.Database.MigrateAsync();
//			}
//		}
//		catch (Exception ex)
//		{
//			_logger.LogError(ex, "An error occurred while initialising the database.");
//			throw;
//		}
//	}

//	public async Task SeedAsync()
//	{
//		try
//		{
//			await TrySeedAsync();
//		}
//		catch (Exception ex)
//		{
//			_logger.LogError(ex, "An error occurred while seeding the database.");
//			throw;
//		}
//	}
//}

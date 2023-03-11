//using Application.Common.Interfaces;
//using Common.Models;

// TODO: remove
//namespace Infrastructure.Identity
//{
//	internal class TempIdentityService : IIdentityService
//	{
//		public async Task<string?> GetUserNameAsync(string userId)
//		{
//			return await Task.FromResult("Tester");
//		}

//		public async Task<bool> IsInRoleAsync(string userId, string role)
//		{
//			return await Task.FromResult(true);
//		}

//		public async Task<bool> AuthorizeAsync(string userId, string policyName)
//		{
//			return await Task.FromResult(true);
//		}

//		public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
//		{
//			var ret = (Result.Success(), "-1");
//			return await Task.FromResult(ret);
//		}

//		public async Task<Result> DeleteUserAsync(string userId)
//		{
//			return await Task.FromResult(Result.Success());
//		}
//	}
//}

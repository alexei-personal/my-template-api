//using System.Reflection;
//using Application.Common.Exceptions;
//using Application.Common.Interfaces;
//using Application.Common.Security;
//using MediatR;

//namespace Application.Common.Behaviours;

//TODO: check if needed
//public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
//	where TRequest : IRequest<TResponse>
//{
//	private readonly ICurrentUserService _currentUserService;
//	private readonly IIdentityService _identityService;

//	public AuthorizationBehaviour(
//		ICurrentUserService currentUserService,
//		IIdentityService identityService)
//	{
//		_currentUserService = currentUserService;
//		_identityService = identityService;
//	}

//	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
//	{
//		var authorizeAttributes = request.GetType()
//			.GetCustomAttributes<AuthorizeAttribute>()
//			.ToList();

//		if (!authorizeAttributes.Any()) 
//			return await next();

//		// Must be authenticated user
//		if (_currentUserService.UserId == null)
//			throw new UnauthorizedAccessException();

//		// Role-based authorization
//		var authorizeAttributesWithRoles = authorizeAttributes
//			.Where(a => !string.IsNullOrWhiteSpace(a.Roles))
//			.ToList();

//		await CheckAuthorizeAttributesWithRoles(authorizeAttributesWithRoles);

//		// Policy-based authorization
//		var authorizeAttributesWithPolicies = authorizeAttributes
//			.Where(a => !string.IsNullOrWhiteSpace(a.Policy))
//			.ToList();
//		if (!authorizeAttributesWithPolicies.Any()) 
//			return await next();

//		await CheckPolicyBasedAuthorization(authorizeAttributesWithPolicies);

//		// User is authorized / authorization not required
//		return await next();
//	}

//	private async Task CheckPolicyBasedAuthorization(List<AuthorizeAttribute> authorizeAttributesWithPolicies)
//	{
//		foreach (string policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
//		{
//			bool authorized = await _identityService.AuthorizeAsync(
//				_currentUserService.UserId ?? "", policy);

//			if (!authorized)
//				throw new ForbiddenAccessException();
//		}
//	}

//	private async Task CheckAuthorizeAttributesWithRoles(List<AuthorizeAttribute> authorizeAttributesWithRoles)
//	{
//		if (authorizeAttributesWithRoles.Any())
//		{
//			var authorized = false;

//			foreach (string[] roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
//			{
//				foreach (string role in roles)
//				{
//					bool isInRole = await _identityService.IsInRoleAsync(
//						_currentUserService.UserId ?? "", role.Trim());
//					if (!isInRole)
//						continue;

//					authorized = true;
//					break;
//				}
//			}

//			// Must be a member of at least one role in roles
//			if (!authorized)
//				throw new ForbiddenAccessException();
//		}
//	}
//}
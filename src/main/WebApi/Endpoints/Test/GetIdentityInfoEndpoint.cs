using Application.Common.Interfaces;
using FastEndpoints;
using WebApi.Endpoints.Base;

namespace WebApi.Endpoints.Test;

public class GetIdentityInfoEndpoint : EndpointWithoutRequestBase<object>
{
	private readonly ILogger<GetIdentityInfoEndpoint> _logger;
	private readonly ICurrentUserService _currentUserService;

	public GetIdentityInfoEndpoint(ILogger<GetIdentityInfoEndpoint> logger, ICurrentUserService currentUserService)
	{
		_logger = logger;
		_currentUserService = currentUserService;
	}

	public override void Configure()
	{
		Get("test/identity-info");

		Description(b => b
			.Produces<object>(StatusCodes.Status200OK, "application/json")
			.Produces(StatusCodes.Status401Unauthorized), clearDefaults: true
		);
		Summary(s =>
		{
			s.Summary = "get quick information about the logged in user";
		});

		base.Configure();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		_logger.LogInformation("GetIdentityInfoEndpoint called");

		var ret = new
		{
			UserIdentityName = User.Identity?.Name ?? "null",
			OperatorUsername = _currentUserService.UserId,
			Groups = User?.FindAll("groups").Select(c => c.Value)
		};

		await SendOkAsync(ret, ct);
	}
}
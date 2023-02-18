using WebApi.Endpoints.Base;

namespace WebApi.Endpoints.Test;

internal sealed class EchoEndpoint : EndpointBase<EchoPayload, EchoPayload>
{
	private readonly ILogger<EchoEndpoint> _logger;

	public EchoEndpoint(ILogger<EchoEndpoint> logger)
	{
		_logger = logger;
	}

	public override void Configure()
	{
		Get("test/echo");

		Description(b => b
				.Produces<EchoPayload>(StatusCodes.Status200OK, "application/json")
				.Produces(StatusCodes.Status401Unauthorized), 
			clearDefaults:true
		);

		Summary(s =>
		{
			s.Summary = "quick test to echo the received payload";
		});

		base.Configure();
	}

	public override async Task HandleAsync(EchoPayload req, CancellationToken token)
	{
		_logger.LogInformation("Echo called");

		await SendOkAsync(req, token);
	}
}

internal sealed class EchoPayload
{
	public string? Message { get; set; }
}
using FastEndpoints;
using MediatR;

namespace WebApi.Endpoints.Base;

public abstract class EndpointBase<TReq, TRes>: Endpoint<TReq, TRes>
	where TReq : notnull, new()
	where TRes:  notnull, new()
{
	private IMediator? _mediator = default;

	protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

	public override void Configure()
	{
		//TODO: remove when security is implemented
		AllowAnonymous();

		Options(opt => opt.RequireCors("CorsPolicy"));

		Summary(s =>
		{
			s[StatusCodes.Status200OK] = "OK";
			s.Responses[StatusCodes.Status400BadRequest] = "Validation error";
		});
	}
}
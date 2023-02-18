using FastEndpoints;

namespace WebApi.Endpoints.Base;

public abstract class EndpointWithoutRequestBase<TRes>: EndpointBase<EmptyRequest, TRes>
	where TRes : notnull, new()
{
}
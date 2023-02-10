using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.ExceptionHandling;

public interface IGlobalExceptionHandler
{
	void HandleException(IExceptionHandlerFeature exceptionContext, HttpContext httpContext);
}

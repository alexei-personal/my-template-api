using System.Net;
using Application.Common.Exceptions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;

namespace Infrastructure.ExceptionHandling;

public sealed class GlobalExceptionHandler : IGlobalExceptionHandler
{
	private readonly IDictionary<Type, Action<IExceptionHandlerFeature, HttpContext>> _exceptionHandlers;
	private readonly ILogger<GlobalExceptionHandler> _logger;

	public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
	{
		_logger = logger;

		// Register known exception types and handlers.
		_exceptionHandlers = new Dictionary<Type, Action<IExceptionHandlerFeature, HttpContext>>
		{
			{typeof(FluentValidation.ValidationException), HandleValidationException},
			{typeof(NotFoundException), HandleNotFoundException},
			{typeof(ForbiddenAccessException), HandleForbiddenAccessException },

			{typeof(OperationCanceledException), HandleOperationCanceledException },
			{typeof(TaskCanceledException), HandleTaskCanceledException }
		};
	}

	public void HandleException(IExceptionHandlerFeature exceptionContext, HttpContext httpContext)
	{
		Type type = exceptionContext.Error.GetType();
		if (_exceptionHandlers.ContainsKey(type))
		{
			_exceptionHandlers[type].Invoke(exceptionContext, httpContext);
			return;
		}

		// Refit exception is treated separately
		if (type == typeof(ValidationApiException))
		{
			HandleRefitApiException((ValidationApiException)exceptionContext.Error, httpContext);
			return;
		}

		HandleUnknownException(exceptionContext, httpContext);
	}

	private void HandleRefitApiException(ValidationApiException validationApiException, HttpContext httpContext)
	{
		switch (validationApiException.StatusCode)
		{
			case HttpStatusCode.InternalServerError:
				HandleInternalServerErrorException(httpContext, $"A Refit internal server error was raised: {validationApiException.Message}");
				break;
			case HttpStatusCode.BadRequest:
				httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
				var retBad = new { value = validationApiException.Content, statusCode = StatusCodes.Status400BadRequest };
				var taskBad = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(retBad));
				taskBad.Wait();
				break;
			case HttpStatusCode.NotFound:
				httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
				var retNotFound = new { value = validationApiException.Content, statusCode = StatusCodes.Status404NotFound };
				var taskNotFound = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(retNotFound));
				taskNotFound.Wait();
				break;
			default:
				HandleInternalServerErrorException(httpContext, $"An unknown Refit server error was raised with status code = {validationApiException.StatusCode} and message = {validationApiException.Message}");
				break;
		}
	}

	private void HandleOperationCanceledException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		_logger.LogInformation(context.Error, "An OperationCanceledException was detected");

		// do not handle because this also logs an error event
		// HandleInternalServerErrorException(context, "An OperationCanceledException was detected.");
	}

	private void HandleTaskCanceledException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		_logger.LogInformation(context.Error, "An TaskCanceledException was detected");

		// do not handle because this also logs an error event
		// HandleInternalServerErrorException(context, "An TaskCanceledException was detected.");
	}

	private void HandleUnknownException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		_logger.LogError(context.Error, "Unknown exception reached API boundary");
		HandleInternalServerErrorException(context, httpContext, "An error occurred while processing your request.");
	}

	private void HandleInternalServerErrorException(IExceptionHandlerFeature errorContext, HttpContext httpContext, string title)
	{
		HandleInternalServerErrorException(httpContext, title);
	}

	private void HandleInternalServerErrorException(HttpContext httpContext, string title)
	{
		var details = new ProblemDetails
		{
			Status = StatusCodes.Status500InternalServerError,
			Title = title,
			Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
		};

		var result = new ObjectResult(details)
		{
			StatusCode = StatusCodes.Status500InternalServerError
		};

		httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

		var task = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(result));
		task.Wait();
	}

	private void HandleValidationException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		var exception = context.Error as FluentValidation.ValidationException;
		var problemDetails = exception?.ToProblemDetails();

		var result = new BadRequestObjectResult(problemDetails);

		httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

		var task = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(result));
		task.Wait();
	}

	private void HandleNotFoundException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		var exception = (NotFoundException)context.Error;
		HandleNotFoundException(exception, httpContext);
	}

	private void HandleNotFoundException(NotFoundException exception, HttpContext httpContext)
	{
		var problemDetails = new ProblemDetails()
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
			Title = "The specified resource was not found.",
			Detail = exception?.Message
		};

		var result = new BadRequestObjectResult(problemDetails);

		httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

		var task = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(result));
		task.Wait();
	}

	private void HandleForbiddenAccessException(IExceptionHandlerFeature context, HttpContext httpContext)
	{
		var details = new ProblemDetails
		{
			Status = StatusCodes.Status403Forbidden,
			Title = "Forbidden",
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.3"
		};

		var result = new ObjectResult(details)
		{
			StatusCode = StatusCodes.Status403Forbidden
		};

		httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;

		var task = Task.Run(async () => await httpContext.Response.WriteAsJsonAsync(result));
		task.Wait();
	}
}

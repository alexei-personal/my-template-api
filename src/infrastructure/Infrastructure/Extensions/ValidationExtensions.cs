using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Extensions;

public static class ValidationExtensions
{
	public static ValidationProblemDetails ToProblemDetails(this ValidationException ex)
	{
		var details = new ValidationProblemDetails
		{
			Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
			Title = "One or more validation errors occurred.",
			Status = StatusCodes.Status400BadRequest
		};

		foreach (var error in ex.Errors)
		{
			string? propertyName = error.PropertyName;
			string? errorMessage = error.ErrorMessage;
			if (!details.Errors.ContainsKey(propertyName))
			{
				details.Errors[propertyName] = new[] { errorMessage };
			}
			else
			{
				// concatenate errors for the same property name
				details.Errors[propertyName] = details.Errors[propertyName]
					.Concat(new[] { errorMessage })
					.ToArray();
			}
		}

		return details;
	}

}

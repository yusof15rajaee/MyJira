using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Project.Api.Exceptions;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;

        object errorDetails;

        switch (exception)
        {
            case ValidationException validationException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                errorDetails = new
                {
                    message = "Validation failed.",
                    errors = validationException.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage).ToArray())
                };
                break;

            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorDetails = new { message = exception.Message };
                break;
        }

        var result = JsonSerializer.Serialize(errorDetails);
        return context.Response.WriteAsync(result);
    }
}

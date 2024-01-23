using System.Net;
using Domain.Dtos;
using Domain.Exceptions;

namespace WebApp.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _request;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate request, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _request = request;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (NotFoundException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
    {
        _logger.LogError(message);
        
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)statusCode;

        var error = new ErrorDto
        {
            Message = message,
            StatusCode = (int)statusCode
        };

        await response.WriteAsJsonAsync(error);
    }
}

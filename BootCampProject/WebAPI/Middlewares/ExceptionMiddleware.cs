using Core.BusinessException;
using Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebAPI.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BusinessException ex)
        {
            _logger.LogError($"İş kuralı hatası: {ex.Message}");
            await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status400BadRequest);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning($"Bulunamadı hatası: {ex.Message}");
            await HandleExceptionAsync(httpContext, ex.Message, StatusCodes.Status404NotFound);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Sistem hatası: {ex.Message}");
            await HandleExceptionAsync(httpContext, "Sunucuda bir hata oluştu.", StatusCodes.Status500InternalServerError);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new { message }));
    }
}

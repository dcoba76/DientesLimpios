using DientesLimpios.Aplicacion.Excepciones;
using System.Net;

namespace DientesLimpios.API.Middlewares;

public class ManejadorExcepcionesMiddleware
{
    private readonly RequestDelegate _next;

    public ManejadorExcepcionesMiddleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {

        }
    }

    private Task ManejarExcepcion(HttpContext context, Exception exception)
    {
        HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";
        var resultado = string.Empty;

        switch (exception)
        {
            case ExcepcionNoEncontrado:
                httpStatusCode = HttpStatusCode.NotFound;
                break;
            case ExcepcionDeValidacion excepcionDeValidacion:
                httpStatusCode = HttpStatusCode.BadRequest;
                var errores = excepcionDeValidacion.ErroresDeValidacion;
                resultado = System.Text.Json.JsonSerializer.Serialize(excepcionDeValidacion.ErroresDeValidacion);
                break;
            default:
                break;
        }

        context.Response.StatusCode = (int)httpStatusCode;
        return context.Response.WriteAsync(resultado);
    }

}


public static class ManejadorExcepcionesMiddlewareExtensions
{
    public static IApplicationBuilder UseManejadorExcepcionesMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ManejadorExcepcionesMiddleware>();
    }
}
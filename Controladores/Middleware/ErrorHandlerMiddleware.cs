using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Controladores.Middleware
{
  
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApplicationException exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(new { message = exception?.Message });
                await response.WriteAsync(result);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new { message = "Error de Concurrecia" });
                await response.WriteAsync(result);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new { message = "Error al guardar en la base de datos" });
                await response.WriteAsync(result);
            }
           
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(new { message = exception?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}

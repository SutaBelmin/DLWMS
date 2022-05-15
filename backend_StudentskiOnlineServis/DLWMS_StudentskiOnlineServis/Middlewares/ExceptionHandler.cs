using DLWMS_StudentskiOnlineServis.Exceptions;
using DLWMS_StudentskiOnlineServis.Services;
using DLWMS_StudentskiOnlineServis.Services.Responses;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Studentski_online_servis.Helper;
using System.Threading.Tasks;

namespace DLWMS_StudentskiOnlineServis.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var errorService = context.RequestServices.GetService(typeof(IErrorService)) as IErrorService;
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                });
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = e.Message
                });
            }
            catch (System.Exception e)
            {
                errorService.AddError(new Services.Requests.AddErrorRequest
                {
                    Method = context.Request.Method,
                    Url= context.Request.Path,
                    Message = e?.InnerException?.Message ?? e.Message,
                    KorisnickiNalogId = context.GetLoginInfo()?.korisnickiNalog?.ID
                });
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal Server Error"
                });
            }
        }
    }

    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            return app;
        }
    }
}

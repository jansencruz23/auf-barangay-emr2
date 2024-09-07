using AUF.EMR2.API.Models;
using AUF.EMR2.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AUF.EMR2.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError;
            var problemDetails = new CustomProblemDetails
            {
                Title = exception.Message,
                Detail = exception.InnerException?.Message
            };

            switch (exception)
            {
                case ValidationException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(ValidationException);
                    problemDetails.Errors = ex.Errors;
                    break;

                case NotFoundException ex:
                    statusCode = HttpStatusCode.NotFound;
                    problemDetails.Type = nameof(NotFoundException);
                    break;

                case BadRequestException ex:
                    statusCode = HttpStatusCode.BadRequest;
                    problemDetails.Type = nameof(BadRequestException);
                    break;

                case DbUpdateConcurrencyException ex:
                    statusCode = HttpStatusCode.Conflict;
                    var concurrencyException = new ConcurrencyException("A concurrency error occurred.", ex);
                    problemDetails.Type = nameof(DbUpdateConcurrencyException);
                    break;

                case DataIntegrityException ex:
                    statusCode = HttpStatusCode.InternalServerError;
                    problemDetails.Type = nameof(DataIntegrityException);
                    break;

                default:
                    problemDetails.Type = nameof(HttpStatusCode.InternalServerError);
                    problemDetails.Detail = exception.StackTrace;
                    break;
            }

            problemDetails.Status = (int)statusCode;
            httpContext.Response.StatusCode = (int)statusCode;

            await httpContext.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}

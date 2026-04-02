using FundAdmin.API.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace FundAdmin.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var problem = new ProblemDetails
            {
                Instance = context.Request.Path
            };

            switch (ex)
            {
                case BadRequestException:
                    problem.Title = "Bad Request";
                    problem.Status = (int)HttpStatusCode.BadRequest;
                    problem.Detail = ex.Message;
                    break;

                case NotFoundException:
                    problem.Title = "Resource Not Found";
                    problem.Status = (int)HttpStatusCode.NotFound;
                    problem.Detail = ex.Message;
                    break;

                default:
                    problem.Title = "Internal Server Error";
                    problem.Status = (int)HttpStatusCode.InternalServerError;
                    problem.Detail = "Something went wrong";
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = problem.Status.Value;

            var result = JsonSerializer.Serialize(problem);
            return context.Response.WriteAsync(result);
        }
    }
}

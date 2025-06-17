using Demo_Design_Pattern_MediaTor.Common;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Demo_Design_Pattern_MediaTor.Middlewares
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

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            var response = new BaseResponse<object>
            {
                Success = false,
                Data = null
            };

            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Dữ liệu không hợp lệ";
                response.Errors = ex.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}").ToList();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                var jsonValidation = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonValidation);
            }
            catch (ApplicationException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                response.Errors.Add(ex.InnerException?.Message ?? ex.Message);
                var jsonApp = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonApp);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.Message = "Lỗi hệ thống";
                response.Errors.Add(ex.Message);
                _logger.LogError(ex, "Unhandled exception");
                var jsonUnknown = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(jsonUnknown);
            }

        }
    }
}

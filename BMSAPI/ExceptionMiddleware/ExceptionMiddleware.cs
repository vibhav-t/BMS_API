﻿using BMSAPI.Helpers.ErrorResponseDTO;
using System.Net;

namespace BMSAPI.ExceptionMiddleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) 
        {
            _next = next; _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        { 
            try 
            { 
                await _next(context);
            } 
            catch (Exception ex) 
            { 
                _logger.LogError(ex, "An exception occurred."); 
                await HandleExceptionAsync(context, ex);
            } 
        }
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(new ErrorDetails {
                StatusCode = context.Response.StatusCode, 
                Message = exception.Message 
            }.ToString());
        }
    }
}

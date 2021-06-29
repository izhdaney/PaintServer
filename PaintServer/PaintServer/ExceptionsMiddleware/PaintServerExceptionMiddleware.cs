using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;
using PaintServer.Exeptions;

namespace PaintServer.Middleware
{
    public class PaintServerExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public PaintServerExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task  Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AccessLevelException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        break;
                    case Exception e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                //var result = JsonSerializer.Serialize(new { message = error?.Message });
                var result = error?.Message;
                await  response.WriteAsync(result);
                
            }
            
        }
    }
}

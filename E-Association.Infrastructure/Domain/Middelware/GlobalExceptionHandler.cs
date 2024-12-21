using Microsoft.AspNetCore.Builder;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
namespace E_Association.Core.Domain.Middelware
{
    public static class GlobalExceptionHandler
    {
        public static void ExceptionGlobalHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler( x => x.Run(async context =>
            {
                var errorFeatures = context.Features.Get<IExceptionHandlerFeature>();
                var exception = errorFeatures.Error;

                // after get exception cheek if it for requestpipeline or not
                if (!(exception is FluentValidation.ValidationException ValidationException))
                    throw exception;
                // in this case exception for validation exception and you must handel it
                // read error for validationExcep

                var errors = ValidationException.Errors.Select(error => new
                {
                    PropertyName = error.PropertyName,
                    PropertyMessage = error.ErrorMessage
                });

                // after this you must serlize error as json file for send to user
                var jsonError = JsonSerializer.Serialize(errors);

                //bad request becuse this is related by user request
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(jsonError,System.Text.Encoding.UTF8);

            }));
               
            // after all this you must register middlerware
        }
    }
}
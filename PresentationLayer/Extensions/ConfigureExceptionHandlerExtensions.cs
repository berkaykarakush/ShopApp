using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using System.Net.Mime;

namespace PresentationLayer.Extensions
{
    public static class ConfigureExceptionHandlerExtensions
    {
        public static void UseConfigureExceptionHandler(this WebApplication application)
        {
            application.UseExceptionHandler(builder =>
            {
                builder.Run(async context => 
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) 
                    {
                        Log.Fatal($"Error Message: {contextFeature.Error.Message} \n\n Error Source: {contextFeature.Error.Source}\n");
                        Log.Error(contextFeature.Error.Message);
                        //await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        //{
                        //    StatusCode = context.Response.StatusCode,
                        //    Message = contextFeature.Error.Message,
                        //    Title = "Error!"
                        //}));
                        await context.Response.WriteAsync($"Error Message: {contextFeature.Error.Message} \n\nError Source: {contextFeature.Error.Source}\n");
                    }
                });
            });
        }
    }
}

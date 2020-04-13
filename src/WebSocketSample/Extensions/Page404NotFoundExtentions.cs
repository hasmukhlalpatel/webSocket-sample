using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebSocketSample.Extensions
{
    public static class Page404NotFoundExtentions
    {
        public static IApplicationBuilder Use404NotFound(this IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.ContentType = "text/html";
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(string.Format(Constants.HtmlBodyStart, "Notfound"));

                await context.Response.WriteAsync(Constants.HtmlBodyEnd);

            });

            return app;
        }
    }
}

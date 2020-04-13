using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;

namespace WebSocketSample.Extensions
{
    public static class ConfigAddressesExtentions
    {
        public static IApplicationBuilder UseConfigAddresses(this IApplicationBuilder app)
        {
            return app.Map("/config/addresses", HandleMapConfigAddresses);
        }

        private static void HandleMapConfigAddresses(IApplicationBuilder app)
        {
            var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(string.Format(Constants.HtmlBodyStart, "Addresses"));

                if (serverAddressesFeature != null)
                {
                    await context.Response
                        .WriteAsync("<p>Listening on the following addresses: " +
                            string.Join(", ", serverAddressesFeature.Addresses) +
                            "</p>");
                }

                await context.Response.WriteAsync("<p>Request URL: " + $"{context.Request.Path + context.Request.QueryString }<p>");
                await context.Response.WriteAsync(Constants.HtmlBodyEnd);
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace BDSA2016.Lecture08.App
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseFileServer();

            app.Run(async c => {
                var name = c.Request.QueryString.Value;
                if (string.IsNullOrWhiteSpace(name))
                {
                    name = "World";
                }
                else 
                {
                    name = name.Substring(1);
                }
                await c.Response.WriteAsync($"<h1>Hello {name} from the web</h1>");
                
            });



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OdeToFoodCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
                              IHostingEnvironment env,
                              IGreeter greeter)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            /**
             * DefaultFiles will look at the incoming request. 
             * If that request is for a directory like the root of the application
             * this middleware will look inside of that directory to see if there is
             * a default file. The name of the default file is configurable.
             * One of the default of the default filenames is index.html.  
             * UseDefaultFiles won't serve up the default file, it won't read that file
             * from file system and send it back to the user.
             * UseDefaultFiles will change the request path and then invoke the next middleware,
             * which is UseStaticFiles, which will serve up the content.
             */
            //app.UseDefaultFiles();

            //app.UseStaticFiles();


            // UseFileServer installs the DefaultFiles and StaticFiles middlewares
            app.UseFileServer();
           
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");
            });
        }
    }
}

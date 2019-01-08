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
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}


            /**
             * The UseWelcomePage middleware responses to every request by default and 
             * displays a simple welcome page. 
             * The order in which you install middleware is very important. 
             * The middleware we have inside of the app.Run, that displays a greeting, 
             * will never display that greeting because the UseWelcomePage will never call 
             * the next middleware.
            */
            //app.UseWelcomePage();



            /** To solve the problem with UseWelcomePage above we can add an Options object to 
             * the middleware.
             * In this case we add WelcomePageOptions to UseWelcomePage which 
             * only responses to the request with a path /wp
            */
            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/wp"     
            });


            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}

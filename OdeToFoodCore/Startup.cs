using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OdeToFoodCore.Services;

namespace OdeToFoodCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
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

          
            app.UseStaticFiles();


            app.UseMvc(ConfigureRoutes);
       
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync("Not Found is fine");
            });
        }


        // Defines a route for the application with a given template 
        // The template will be used for controller instantiation and method invocation
        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // We want to map the incoming request like /Home/Index to the Index action 
            // of HomeController
            // The controller's name can be found in the first part of the URL
            // The action's name can be found in the second part of the URL

            //routeBuilder.MapRoute("Default", "{controller}/{action}");


            // Controller that has to look up a record in a database needs an identifier
            //routeBuilder.MapRoute("Default", "{controller}/{action}/{id}");


            // The third part is optional
            // This will print "Not Found is fine" when we go to the root of the website
            //routeBuilder.MapRoute("Default", "{controller}/{action}/{id?}");


            // With this default conventional route we can reach HomeController's Index action
            // by going to the root of the website or by going to /home
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

        }
    }
}

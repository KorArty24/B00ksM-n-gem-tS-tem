using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using AspNetCorePublisherWebAPI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


namespace AspNetCorePublisherWebAPI
{

    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true);
            if (env.IsDevelopment()) builder.AddUserSecrets<Startup>();
          
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var conn = Configuration["connectionStrings:sqlConnection"];
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(conn));
            services.AddScoped(typeof(IBookstoreRepository), typeof(BookstoreSqlRepository));
            services.AddAutoMapper(typeof(BookstoreSqlRepository).Assembly);


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
           // app.UseStatusCodePages();
            app.UseMvc();
          //  app.Run(async (context) =>
          //  {
          //      
          //      var message = Configuration["Message"];
          //      await context.Response.WriteAsync(message);
          //  });
        }
        

    }
}

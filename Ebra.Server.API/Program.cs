using Ebra.Server.API.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        //var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //var app = builder.Build();

        // Configure the HTTP request pipeline.
        
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStaticWebAssets();
                  webBuilder.UseStartup<Startup>();
              }).ConfigureAppConfiguration(builder =>
              {
                  //  builder.AddJsonFile("balea.json", optional: false, reloadOnChange: true);
              });
      //.UseWindowsService();

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAutoMapper(typeof(EbraAutoMapperConfiguration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => 
            { 
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
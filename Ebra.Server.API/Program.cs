using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

internal partial class Program
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
}
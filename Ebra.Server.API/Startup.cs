using Ebra.Server.API.Mappings;

internal partial class Program
{
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

            //app.UseCors(builder => 
            //{
            //    //builder.WithOrigins("http://DESKTOP-NLDOJUC", "http://192.168.1.34").AllowAnyHeader().AllowAnyMethod();
            //    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            //});
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
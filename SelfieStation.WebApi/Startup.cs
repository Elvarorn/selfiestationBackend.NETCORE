using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SelfieStation.Repositories.data;
using SelfieStation.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using SelfieStation.Services;

namespace SelfieStation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "selfiestationserver.database.windows.net";
            builder.UserID = "selfieAdmin";
            builder.Password = "SelfieStation-1337";
            builder.InitialCatalog = "SelfieStationDb";

            SqlConnection connection = new SqlConnection(builder.ConnectionString);
            services.AddDbContextPool<databaseContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("SelfieStation")));

            services.AddControllers();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IAdRepository, AdRepository>();
            services.AddScoped<IAdService, AdService>();
            services.AddScoped<IImageService, imageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

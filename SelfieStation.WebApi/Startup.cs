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
using Swashbuckle.AspNetCore.Swagger;

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
            services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<IShopifyService, ShopifyService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API docs", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
                c.RoutePrefix = string.Empty;
            });

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

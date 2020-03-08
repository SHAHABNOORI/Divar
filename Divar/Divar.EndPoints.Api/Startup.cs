using Divar.Core.ApplicationService.Advertisements.CommandHandlers;
using Divar.Core.Domain.Advertisements.Data;
using Divar.Framework.Domain.Data;
using Divar.Infrastructures.Data.SqlServer;
using Divar.Infrastructures.Data.SqlServer.Advertisements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Divar.EndPoints.Api
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
            services.AddControllers();
            services.AddDbContext<DivarDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, AdvertisementUnitOfWork>();
            //services.AddSingleton<IAdvertisementRepository, FakeAdvertisementRepository>();
            services.AddScoped<IAdvertisementRepository, EfAdvertisementRepository>();

            services.AddScoped<CreateHandler>();
            services.AddScoped<RequestToPublishHandler>();
            services.AddScoped<UpdateDescriptionHandler>();
            services.AddScoped<UpdatePriceHandler>();
            services.AddScoped<UpdateTitleHandler>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Divar Api", Version = "v1" });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Divar API V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

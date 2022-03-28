using Meter.Api.Helpers;
using Meter.Infrastructure;
using Meter.Infrastructure.DbContexts;
using Meter.Infrastructure.Repositories;
using Meter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Meter.Api
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
            services.AddMvc();
            services.AddScoped<ICsvHelper, Helpers.CsvHelper>();
            services.AddDbContext<MeterReadingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IMeterReadingValidator, MeterReadingValidator>();
            services.AddScoped<IMeterService, MeterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
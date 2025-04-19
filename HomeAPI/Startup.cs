using HomeApi.Configuration;
using Microsoft.OpenApi.Models;

namespace HomeAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration{ get; } = new ConfigurationBuilder()
            .AddJsonFile("HomeOptions.json")
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<HomeOptions>(Configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthenticationService", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthenticationService v1"));
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


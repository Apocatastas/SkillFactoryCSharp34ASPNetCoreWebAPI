using FluentValidation.AspNetCore;
using HomeApi.Configuration;
using HomeAPI;
using HomeAPI.Contracts.Validation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation;

public class Startup
{
    private IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .AddJsonFile("appsettings.Development.json")
        .AddJsonFile("HomeOptions.json")
        .Build();

    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<HomeOptions>(Configuration);

        services.AddControllers();
        var assembly = Assembly.GetAssembly(typeof(MappingProfile));
        services.AddAutoMapper(assembly);

        services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeApi", Version = "v1" }); });
        services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDeviceRequestValidator>());


    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApi v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}
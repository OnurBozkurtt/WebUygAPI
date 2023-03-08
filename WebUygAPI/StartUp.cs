using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.OpenApi.Models;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddControllers().AddNewtonsoftJson();
        services.AddMvc(options =>
        {
            options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
        });


        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "DrawValue" });
            c.CustomSchemaIds(x => x.FullName); 
            c.DocumentFilter<JsonPatchDocumentFilter>();
        });

            services.AddCors(options =>
     options.AddDefaultPolicy(builder =>
     builder.WithOrigins("https://localhost:7130", "https://localhost:5166").SetIsOriginAllowedToAllowWildcardSubdomains()
           .AllowAnyHeader().AllowAnyMethod().AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    public static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
    {
        var builder = new ServiceCollection()
            .AddLogging()
            .AddMvc()
            .AddNewtonsoftJson()
            .Services.BuildServiceProvider();

        return builder
            .GetRequiredService<IOptions<MvcOptions>>()
            .Value
            .InputFormatters
            .OfType<NewtonsoftJsonPatchInputFormatter>()
            .First();
    }
}

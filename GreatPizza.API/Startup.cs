using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Swashbuckle;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;

namespace GreatPizza.API
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

      // Register the Swagger generator, defining 1 or more Swagger documents
      services.AddSwaggerGen(options =>
      {
        //Determine base path for the application.

        var basePath = AppContext.BaseDirectory;
        var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        var fileName = System.IO.Path.GetFileName(assemblyName + ".xml");
        //Set the comments path for the swagger json and ui.
        options.IncludeXmlComments(System.IO.Path.Combine(basePath, fileName));


        options.CustomSchemaIds(type => type.ToString());

        options.SwaggerDoc("v1",
            new Microsoft.OpenApi.Models.OpenApiInfo
            {
              Title = "Swagger Great Pizza API",
              Description = "Great Pizza API for showing Swagger",
              Version = "v1"
            });

      });

    } 

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      if (env.IsDevelopment() || env.IsProduction())
      {
        app.UseDeveloperExceptionPage();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger(c =>
        {
          c.SerializeAsV2 = true;
        });

        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("../swagger/v1/swagger.json", "GreatPizzaAPI V1");
        });
      }

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });

      //// Enable middleware to serve generated Swagger as a JSON endpoint.
      //app.UseSwagger();

      //// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
      //// specifying the Swagger JSON endpoint.
      //app.UseSwaggerUI(c =>
      //{
      //  c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      //  c.RoutePrefix = string.Empty;
      //});

    }
  }
}

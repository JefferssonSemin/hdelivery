using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using str.Data;

namespace EFCore.Multitenant
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EFCore.Multitenant", Version = "v1" });
            });

            services.AddDbContext<ApplicationContext>(p => 
            p.UseSqlServer(Configuration.GetConnectionString("Tenant"))
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EFCore.Multitenant v1"));
            }

            // DatabaseInitialize(app);
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    //     private void DatabaseInitialize(IApplicationBuilder app){
            
    //         using var db = app.ApplicationServices
    //         .CreateScope()
    //         .ServiceProvider
    //         .GetRequiredService<ApplicationContext>();
        
    //     db.Database.EnsureDeleted();
    //     db.Database.EnsureCreated();

    //     for (int i = 1; i <= 5; i++)
    //     {
    //         db.Store.Add(new src.Domain.Store{Name = $"Store {i}"});
    //         db.Products.Add(new src.Domain.Product{Description = $"Procuct {i}"});

    //         db.SaveChanges();
    //     }
        
    //     }
    // }
}

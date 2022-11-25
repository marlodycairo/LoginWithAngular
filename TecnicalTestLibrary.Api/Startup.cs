using FluentValidation.AspNetCore;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecnicalTestLibrary.Api.Application;
using TecnicalTestLibrary.Api.ApplicationService;
using TecnicalTestLibrary.Api.Domain;
using TecnicalTestLibrary.Api.Domain.Filters;
using TecnicalTestLibrary.Api.DomainService;
using TecnicalTestLibrary.Api.Infrastructure.Context;
using TecnicalTestLibrary.Api.Infrastructure.Repositories;
using TecnicalTestLibrary.Api.Infrastructure.Repositories.IRepositories;

namespace TecnicalTestLibrary.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddMvc(options => options.Filters.Add<ValidationFilter>())
                .AddFluentValidation(fv =>
                    fv.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            services.AddDbContext<ApplicationDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionDB2"))
                .EnableSensitiveDataLogging();
            });

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IAuthorDomain, AuthorDomainService>();
            services.AddScoped<IAuthorApplication, AuthorApplicationService>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookDomain, BookDomainService>();
            services.AddScoped<IBookApplication, BookApplicationService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TecnicalTestLibrary.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TecnicalTestLibrary.Api v1"));
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

using Corretora.Api.Infrastructure.DependencyInjection;
using Corretora.Infrastructure.Bootstrap;
using Corretora.Infrastructure.Data;
using FluentValidation.AspNetCore;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Corretora.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<Application.Assemblies>();
                    fv.AutomaticValidationEnabled = false;
                }); ;


            services.AddDbContext<CorretoraContext>(options =>
                    options.UseSqlServer(Configuration["ConnectionString"]));

            services
                .ConfigureMediatR()
                .RegisterProblemDetails()
                .ConfigureInfrastructure();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Corretora.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CorretoraContext dataContext)
        {
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {           
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Corretora.Api v1"));
            }

            app.UseProblemDetails();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

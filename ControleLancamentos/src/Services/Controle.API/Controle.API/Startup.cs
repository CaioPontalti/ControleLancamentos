using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controle.API.Config;
using Controle.Domain.Handler.Conta;
using Controle.Domain.Handler.Lancamento;
using Controle.Domain.Interfaces;
using Controle.Infra.Context;
using Controle.Infra.Repositorios;
using Controle.Shared.Configuration;
using Controle.Shared.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Controle.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();


            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtConfiguration(Configuration);

            services.AddSwaggerConfiguration();

            services.AddDbContext<ControleContext>(options => options.UseInMemoryDatabase(databaseName: "DbControle"));
            
            services.AddScoped<CreateContaHandler>();
            services.AddScoped<CreateLancamentoHandler>();

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();


            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerConfiguration();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

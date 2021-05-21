using GAC.GerenciadorDeAtividade.Api.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GAC.GerenciadorDeAtividade.Api
{
    public class Startup
    {
        private readonly string API_BASE_PATH = "/api/atividade";
        private readonly string LocalCorsPolicy = "LocalCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCorsServices(LocalCorsPolicy)
                .AddControllers()
                .AddJsonOptions(opcoes => opcoes.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GAC.GerenciadorDeAtividade.Api", Version = "v0.1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(LocalCorsPolicy);

            app.UseHttpsRedirection();

            app.UsePathBase(new PathString(API_BASE_PATH))
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());

            //app.UseSwagger(opcoes =>
            //{
            //    opcoes.RouteTemplate = "/swagger/{documentName}/swagger.json";
            //});
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
                {
                    swaggerDoc.Servers = new List<OpenApiServer> { new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}{API_BASE_PATH}" } };
                });
            });
            app.UseSwaggerUI(opcoes =>
            {
                opcoes.SwaggerEndpoint("/swagger/v1/swagger.json", "API - Gestão de Atividades v0.1");
                opcoes.RoutePrefix = "swagger";
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace InfnetAtividadesComplementaresApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(config =>
            {
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlComments = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
                config.IncludeXmlComments(xmlComments);
            });

            ConfigureCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("NoCorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            //Swagger
            app.UseSwagger(opcoes =>
            {
                opcoes.RouteTemplate = "swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(opcoes =>
            {
                //habilita swagger a adicionar informa��es de atributo no doc. como [MaxLenght(50)].
                opcoes.ConfigObject = new ConfigObject
                {
                    ShowCommonExtensions = true
                };
                opcoes.SwaggerEndpoint("v1/swagger.json", "API - Gest�o de Atividade Complementar");
                opcoes.RoutePrefix = "swagger";
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(
                        "API est� OK" +
                        "INFNET - Gerenciador de Atividades Complementares");
                });
            });
        }

        private static void ConfigureCors(IServiceCollection servicos)
        {
            servicos.AddCors(opcoes =>
            {
                opcoes.AddPolicy("NoCorsPolicy", builder =>
                {
                    builder.SetIsOriginAllowed((host) => true)
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }

    }
}

using Microsoft.Extensions.DependencyInjection;

namespace InfnetAtividadesComplementaresApi.Extensions
{
    public static class CorsConfigureExtensions
    {
        public static IServiceCollection CorsConfigure(this IServiceCollection servicos)
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

            return servicos;
        }
    }
}

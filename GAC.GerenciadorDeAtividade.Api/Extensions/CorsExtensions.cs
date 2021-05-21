using Microsoft.Extensions.DependencyInjection;

namespace GAC.GerenciadorDeAtividade.Api.Extensions
{
    public static class CorsExtensions
    {
        private static readonly string _hostConfiavel = "*gac.infnet.*";
        public static IServiceCollection AddCorsServices(this IServiceCollection servicos, string nomeDaPolitica)
        {
            servicos
                .AddCors(opcoes =>
                {
                    opcoes.AddPolicy(nomeDaPolitica, builder =>
                    {
                        builder.SetIsOriginAllowed((host) => true)
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader();
                    });

                    opcoes.AddPolicy("PoliticaCors", builder =>
                    {
                        builder.WithOrigins(new string[] { _hostConfiavel })
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .AllowAnyHeader();
                    });
                });

            return servicos;
        }
    }
}

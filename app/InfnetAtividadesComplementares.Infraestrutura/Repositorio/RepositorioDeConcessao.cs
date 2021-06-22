using InfnetAtividadesComplementares.Dominio.Atividades.Interface;
using InfnetAtividadesComplementares.Dominio.Dto;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementares.Infraestrutura.Repositorio
{
    public class RepositorioDeConcessao : IRepositorioDeConcessao
    {
        private readonly string mensagemParaCliente = "Não foi possível executar a operação no repositório de Atividades";
        private readonly string urlApiSheets = "https://reqs6nnqf9.execute-api.us-east-1.amazonaws.com/dev/api";
        private HttpClient _httpClient;

        public RepositorioDeConcessao()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ConcessaoDto> ObterConcessoesPor(int ano, int cursoId)
        {
            var retorno = default(ConcessaoDto);
            try
            {
                string url = $"{urlApiSheets}/concessao/{ano}/{cursoId}";
                var resposta = await _httpClient.GetAsync(url);
                if (!resposta.IsSuccessStatusCode)
                {
                    return retorno;
                }

                var conteudo = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<ConcessaoDto>(conteudo);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw new Exception(mensagemParaCliente);
            }

            return retorno;
        }
    }
}


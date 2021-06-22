using InfnetAtividadesComplementares.Dominio.Atividades.Interface;
using InfnetAtividadesComplementares.Dominio.Atividades.ValueObject;
using InfnetAtividadesComplementares.Dominio.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementares.Infraestrutura.Repositorio
{
    public class RepositorioDeAtividade : IRepositorioDeAtividade
    {
        private readonly string mensagemParaCliente = "Não foi possível executar a operação no repositório de Atividades";
        private readonly string urlApiSheets = "https://reqs6nnqf9.execute-api.us-east-1.amazonaws.com/dev/api";
        private HttpClient _httpClient;

        public RepositorioDeAtividade()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<AtividadeSheetsDto>> ObterAtividadesPor(Documento documento)
        {
            var retorno = default(IEnumerable<AtividadeSheetsDto>);
            try
            {
                string url = $"{urlApiSheets}/atividade-complementar/{documento.ValorFormatadoCpf()}";
                var resposta = await _httpClient.GetAsync(url);
                if (!resposta.IsSuccessStatusCode)
                {
                    return retorno;
                }

                var conteudo = await resposta.Content.ReadAsStringAsync();
                retorno = JsonConvert.DeserializeObject<IEnumerable<AtividadeSheetsDto>>(conteudo);
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

using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject;
using InfnetAtividadesComplementaresApi.App.Domain.GerenciaDeUsuario.Entity.Interface;
using System;
using System.Net.Http;

namespace InfnetAtividadesComplementaresApi.App.Infrastructure.Repository
{
    public class RepositorioDeUsuario : IRepositorioDeUsuario
    {
        private HttpClient _http;

        public RepositorioDeUsuario()
        {
            _http = new HttpClient();
        }

        public Aluno ObterPor(string documento)
        {
            try
            {
                //url api schirru

                //chamada http

            }
            catch (Exception ex)
            {

                throw;
            }

            return CriaAlunoMock(documento);
        }

        private Aluno CriaAlunoMock(string documento)
        {
            return new Aluno()
            {
                AnoDeConcessao = 2018,
                Documento = new Documento(documento),
                Matricula = "1345678900",
                Nome = $"Aluno {documento}",
                TotalHorasRealizadas = 158
            };
        }
    }
}

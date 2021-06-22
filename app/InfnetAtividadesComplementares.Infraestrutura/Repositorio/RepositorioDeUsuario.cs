using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using InfnetAtividadesComplementares.Dominio.Atividades.ValueObject;
using InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface;
using System;
using System.Net.Http;

namespace InfnetAtividadesComplementares.Infraestrutura.Repositorio
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
                var msg = ex.Message;
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

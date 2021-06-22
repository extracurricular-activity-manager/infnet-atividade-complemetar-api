using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using InfnetAtividadesComplementares.Dominio.Atividades.Enum;
using InfnetAtividadesComplementares.Dominio.Atividades.Interface;
using InfnetAtividadesComplementares.Dominio.Atividades.ValueObject;
using InfnetAtividadesComplementares.Servicos.ConsultaDeAtividade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementaresApi.Controllers
{
    [Route("api/atividade")]
    [ApiController]
    //[Authorize]
    [Produces(MediaTypeNames.Application.Json)]
    public class AtividadeController : ControllerBase
    {
        private readonly IRepositorioDeAtividade _repositorioDeAtividade;
        public AtividadeController(IRepositorioDeAtividade repositorioDeAtividade)
        {
            _repositorioDeAtividade = repositorioDeAtividade ??
                throw new Exception("repositorio de attividade não injetado no endpoint de Atividade.");
        }


        /// <summary>
        /// Consulta de Atividades do aluno por documento.
        /// </summary>        
        /// <returns></returns>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Requisição com parametro incorreto.</response>
        /// <response code="500">Erro interno inesperado ao processar a requisição.</response>
        [HttpGet]
        [Route("consulta-atividades")]
        [ProducesResponseType(typeof(IEnumerable<DetalheDeAtividadeView>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetAtividades([FromQuery][Required] string matricula)
        {
            try
            {
                var documento = new Documento(matricula);
                var retorno = await _repositorioDeAtividade.ObterAtividadesPor(documento);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                //Log exception message

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { informacao = ex.Message }
                );
            }
        }

        /// <summary>
        /// Consulta de Atividades do aluno por documento.
        /// </summary>        
        /// <returns></returns>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Requisição com parametro incorreto.</response>
        /// <response code="500">Erro interno inesperado ao processar a requisição.</response>
        [HttpGet]
        [Route("consulta")]
        [ProducesResponseType(typeof(IEnumerable<DetalheDeAtividadeView>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ConsultaDeAtividades()
        {
            var listaAtividades = CriaMockListaDeAtividade();
            var retorno = listaAtividades.Select(atv => new DetalheDeAtividadeView(atv));
            try
            {
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                //Log exception message

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { informacao = ex.Message }
                );
            }
        }

        private IList<Atividade> CriaMockListaDeAtividade()
        {
            var curso = new Curso()
            {
                CursoId = 123,
                HorasExigidas = 400,
                Nome = "Comunicação Social - Publicidade e Propaganda"
            };
            var aluno = new Aluno()
            {
                AnoDeConcessao = 2018,
                Documento = new Documento("12345678900"),
                Matricula = "12345678900",
                TotalHorasRealizadas = 127,
                Curso = curso
            };

            var dataHoje = DateTime.Now;

            return new List<Atividade>() {
                new Atividade
                {
                    Aluno = aluno,
                    RegraDeConcessao = new RegraDeConcessao
                    {
                        Item = "(a)",
                        DescricaoDaAtividade = "Descricao da aividade na regra",
                        DescricaoRegraDeConcessao = "Descricao 1",
                        LimiteDeHoras = 100
                    },
                    Avaliacao = new Avaliacao
                    {
                        DataDaAvaliacao = dataHoje.AddDays(2),
                        HorasConcedidas = 133,
                        NomeDoAvaliador = "Pivotto",
                        Observacao = "Minha simples observação",
                        Revisao = false
                    },
                    Revisao = null,
                    CodigoSequencial = 132132,
                    DataDaAtividade = dataHoje,
                    DataDaSolicitacao = dataHoje,
                    HorasSolicitadas = 50,
                    JustificativaDaSolicitacao = "Só quero o canudo.",
                    TipoDeComprovacao = TipoComprovacaoEnum.Certificado,
                    TipoDeComprovacaoDescricao = TipoComprovacaoEnum.Certificado.ToString(),
                    Observacoes = "alguma observação."
                },
                new Atividade
                {
                    Aluno = aluno,
                    RegraDeConcessao = new RegraDeConcessao
                    {
                        Item = "(b)",
                        DescricaoDaAtividade = "Descricao da aividade na regra",
                        DescricaoRegraDeConcessao = "Descricao 2",
                        LimiteDeHoras = 100
                    },
                    Avaliacao = new Avaliacao
                    {
                        DataDaAvaliacao = dataHoje.AddDays(2),
                        HorasConcedidas = 12,
                        NomeDoAvaliador = "Pivotto",
                        Observacao = "Minha simples observação",
                        Revisao = false
                    },
                    Revisao = new Revisao()
                    {
                        AvaliacaoDaRevisao = new Avaliacao
                        {
                            DataDaAvaliacao = dataHoje,
                            HorasConcedidas = 120,
                            NomeDoAvaliador = "Pivoto dando Revisao",
                            Observacao = "mlk se esforçou",
                            Revisao = true
                        },
                        HorasSolicitadas = 120,
                        Justificativa = "Vale o esforço"
                    },
                    CodigoSequencial = 132132,
                    DataDaAtividade = dataHoje,
                    DataDaSolicitacao = dataHoje,
                    HorasSolicitadas = 10,
                    JustificativaDaSolicitacao = "Só quero o canudo. 2",
                    TipoDeComprovacao = TipoComprovacaoEnum.Declaracao,
                    TipoDeComprovacaoDescricao = TipoComprovacaoEnum.Declaracao.ToString(),
                    Observacoes = "alguma observação."
                },
            };
        }
    }
}

﻿using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Enum;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace InfnetAtividadesComplementaresApi.Controllers
{
    [Route("api/atividade")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class AtividadeController : ControllerBase
    {
        public AtividadeController()
        {

        }

        /// <summary>
        /// Consulta de Atividades do aluno por documento.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns></returns>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Requisição com parametro incorreto.</response>
        /// <response code="500">Erro interno inesperado ao processar a requisição.</response>
        [HttpGet]
        [Route("consulta")]
        [ProducesResponseType(typeof(IEnumerable<Atividade>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ConsultaDeAtividades()
        {
            try
            {
                return Ok(CriaMockListaDeAtividade());
            }
            catch (System.Exception ex)
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
            var aluno = new Aluno()
            {
                AnoDeConcessao = 2018,
                Documento = new Documento("12345678900"),
                Matricula = "12345678900",
                TotalHorasRealizadas = 127
            };

            var dataHoje = DateTime.Now;

            return new List<Atividade>() {
                new Atividade
                {
                    Aluno = aluno,
                    Categoria = new Categoria
                    {
                        DescricaoRegraDeConcessao = "Descricao 2",
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
                    TipoDeComprovacaoDescricao = TipoComprovacaoEnum.Certificado.ToString()
                },
                new Atividade
                {
                    Aluno = aluno,
                    Categoria = new Categoria
                    {
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
                    TipoDeComprovacaoDescricao = TipoComprovacaoEnum.Declaracao.ToString()
                },
            };
        }
    }
}

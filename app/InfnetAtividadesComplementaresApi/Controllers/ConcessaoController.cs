using InfnetAtividadesComplementares.Dominio.Atividades.Interface;
using InfnetAtividadesComplementares.Dominio.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementaresApi.Controllers
{
    [Route("api/concessao")]
    [ApiController]
    public class ConcessaoController : ControllerBase
    {
        private readonly IRepositorioDeConcessao _repositorioDeConcessao;

        public ConcessaoController(IRepositorioDeConcessao repositorioDeConcessao)
        {
            this._repositorioDeConcessao = repositorioDeConcessao;
        }


        /// <summary>
        /// Consulta de concessoes por ano e curso.
        /// </summary>        
        /// <returns></returns>
        /// <response code="200">Consulta realizada com sucesso.</response>
        /// <response code="400">Requisição com parametro incorreto.</response>
        /// <response code="500">Erro interno inesperado ao processar a requisição.</response>
        [HttpGet]
        [Route("{ano}/{cursoId}")]
        [ProducesResponseType(typeof(ConcessaoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetConcessoes(
             [Required] int ano, [Required] int cursoId)
        {
            if (ano == default || cursoId == default)
            {
                return BadRequest();
            }

            try
            {
                var resultado = await _repositorioDeConcessao.ObterConcessoesPor(ano, cursoId);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { mensagem = ex.Message });
            }
        }
    }
}

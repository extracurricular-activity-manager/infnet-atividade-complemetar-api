using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using InfnetAtividadesComplementaresApi.App.Dto.Cmd;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult ConsultaDeAtividades([FromQuery] DocumentoCmd documento)
        {
            try
            {
                return Ok(new Atividade());
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
    }
}

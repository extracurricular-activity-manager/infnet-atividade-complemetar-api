using GAC.GerenciaDeAtividade.Dto.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GAC.GerenciadorDeAtividade.Api.Controllers
{
    [ApiController]
    [Route("gerencia")]
    [Produces(MediaTypeNames.Application.Json)]
    public class GerenciaDeAtividadesController : ControllerBase
    {
        public GerenciaDeAtividadesController()
        {

        }

        /// <summary>
        /// Cadastra nova Atividade Complementar
        /// </summary>
        /// <param name="cadastroAtividadeCmd"></param>
        /// <returns></returns>
        /// <response code="200">Cadastro realizado com sucesso</response>
        /// <response code="400">Dados não preenchidos corretamente</response>        
        /// <response code="500">Ocorreu um erro genérico no processamento</response>
        [HttpPost]
        [Route("{matricula}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CadastroDeAtividade([FromBody] CadastroDeAtividadeCmd cadastroAtividadeCmd, [FromRoute] string matricula)
        {
            return Ok();
        }

        /// <summary>
        /// Edita Atividade Complementar
        /// </summary>
        /// <param name="edicaoAtividadeCmd"></param>
        /// <returns></returns>
        /// <response code="200">Edição realizada com sucesso</response>
        /// <response code="400">Dados não preenchidos corretamente</response>        
        /// <response code="500">Ocorreu um erro genérico no processamento</response>
        [HttpPut]
        [Route("{matricula}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastroDeAtividade([FromBody] EdicaoDeAtividadeCmd edicaoAtividadeCmd, [FromRoute] string matricula)
        {
            return Ok();
        }
    }
}

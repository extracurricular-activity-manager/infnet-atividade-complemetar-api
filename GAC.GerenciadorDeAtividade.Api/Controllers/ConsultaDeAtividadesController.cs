using GAC.GerenciaDeAtividade.Dto.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GAC.GerenciadorDeAtividade.Api.Controllers
{
    [ApiController]
    [Route("consulta")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ConsultaDeAtividadesController : ControllerBase
    {

        public ConsultaDeAtividadesController()
        {

        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ConsultaDeAtividades([FromQuery] FiltroDeAtividades filtro)
        {

            return Ok();
        }
    }
}

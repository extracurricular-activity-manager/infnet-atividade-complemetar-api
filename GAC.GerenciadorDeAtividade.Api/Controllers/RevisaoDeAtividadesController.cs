using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace GAC.GerenciadorDeAtividade.Api.Controllers
{
    [ApiController]
    [Route("revisao")]
    [Produces(MediaTypeNames.Application.Json)]
    public class RevisaoDeAtividadesController : ControllerBase
    {
        public RevisaoDeAtividadesController()
        {

        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ConsultaDeAtividades()
        {

            return Ok();
        }
    }
}

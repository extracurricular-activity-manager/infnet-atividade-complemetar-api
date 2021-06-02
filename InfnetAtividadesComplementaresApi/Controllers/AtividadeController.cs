using Microsoft.AspNetCore.Mvc;

namespace InfnetAtividadesComplementaresApi.Controllers
{
    [Route("api/atividade")]
    [ApiController]
    public class AtividadeController : ControllerBase
    {
        public AtividadeController()
        {

        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Atividade 01");
        }
    }
}

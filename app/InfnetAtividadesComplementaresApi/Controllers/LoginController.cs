using InfnetAtividadesComplementaresApi.App.Application.Login;
using InfnetAtividadesComplementaresApi.App.Domain.GerenciaDeUsuario.Entity.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InfnetAtividadesComplementaresApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepositorioDeUsuario usuarioRepo;
        private readonly IServicoDeLogin servicoDeLogin;

        public LoginController(
            IRepositorioDeUsuario repositorioDeUsuario,
            IServicoDeLogin servicoDeLogin)
        {
            this.usuarioRepo = repositorioDeUsuario;
            this.servicoDeLogin = servicoDeLogin;
        }


        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult Login([FromBody] LoginCmd loginForm)
        {
            var (usuario, token) = servicoDeLogin.Autenticar(loginForm.Documento);

            if (usuario == null)
                return StatusCode(
                    StatusCodes.Status204NoContent,
                    new { informacao = "Usuario não autorizado." });

            return Ok(new
            {
                usuario = usuario,
                token = token
            });
        }


        [HttpGet]
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anomino() => "Você está habilitado no modo anônimo.";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => $"Você está Autenticado - {User.Identity.Name}.";
    }
}

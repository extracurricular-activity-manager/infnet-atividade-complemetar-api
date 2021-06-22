using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InfnetAtividadesComplementares.Servicos.Login
{
    public class ServicoDeLogin : IServicoDeLogin
    {
        private readonly IConfiguration Configs;
        private readonly IRepositorioDeUsuario usuarioRepo;
        public ServicoDeLogin(IConfiguration configs, IRepositorioDeUsuario repositorioDeUsuario)
        {
            Configs = configs;
            usuarioRepo = repositorioDeUsuario;
        }

        public (Aluno, string) Autenticar(string documento)
        {
            var aluno = default(Aluno);
            try
            {
                aluno = usuarioRepo.ObterPor(documento);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw new Exception("Erro inesperado ao buscar informações do Aluno para Login.");
            }
            if (aluno == default(Aluno))
                return (null, string.Empty);

            var token = GerarToken(aluno);
            return (aluno, token);
        }

        public string GerarToken(Aluno aluno)
        {
            var secret = Configs.GetValue<string>("secret");
            var key = Encoding.ASCII.GetBytes(secret);

            // Configurando o token gerado.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // variaveis que ficarao disponiveis pra visualização e itens usados no token.
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, aluno.Nome),
                    new Claim(ClaimTypes.SerialNumber, aluno.Matricula),
                    new Claim(ClaimTypes.NameIdentifier, aluno.Documento.Valor),
                }),
                // Tempo de expiração.
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    // Usando chave simetrica em bytes.
                    new SymmetricSecurityKey(key),
                    // Tipo de encriptação
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            // converter para string.
            return tokenHandler.WriteToken(token);
        }
    }
}

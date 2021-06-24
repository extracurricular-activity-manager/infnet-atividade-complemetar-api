using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InfnetAtividadesComplementares.Servicos.Autenticacao
{
    public class ServicoDeJwt : IServicoDeJwt
    {
        private readonly IConfiguration Configs;
        public ServicoDeJwt(IConfiguration configs)
        {
            Configs = configs;
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

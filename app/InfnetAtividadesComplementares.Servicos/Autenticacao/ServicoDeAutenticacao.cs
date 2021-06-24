using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface;
using System;

namespace InfnetAtividadesComplementares.Servicos.AuthService
{
    public class ServicoDeAutenticacao : IServicoDeAutenticacao
    {
        private readonly IServicoDeJwt _servicoDeJwt;
        private readonly IRepositorioDeUsuario _usuarioRepo;
        public ServicoDeAutenticacao(
            IServicoDeJwt servicoDeJwt,
            IRepositorioDeUsuario repositorioDeUsuario)
        {
            _servicoDeJwt = servicoDeJwt;
            _usuarioRepo = repositorioDeUsuario;
        }

        public (Aluno, string) Autenticar(string documento)
        {
            var aluno = default(Aluno);
            try
            {
                aluno = _usuarioRepo.ObterPor(documento);
                if (aluno == default)
                    return (aluno, string.Empty);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw new Exception("Erro inesperado ao buscar informações do Aluno para Login.");
            }

            var token = _servicoDeJwt.GerarToken(aluno);
            return (aluno, token);
        }


    }
}

using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;

namespace InfnetAtividadesComplementaresApi.App.Domain.GerenciaDeUsuario.Entity.Interface
{
    public interface IRepositorioDeUsuario
    {
        Aluno ObterPor(string documento);
    }
}

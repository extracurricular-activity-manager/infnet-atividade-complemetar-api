using InfnetAtividadesComplementares.Dominio.Atividades.Entity;

namespace InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface
{
    public interface IRepositorioDeUsuario
    {
        Aluno ObterPor(string documento);
    }
}

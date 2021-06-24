using InfnetAtividadesComplementares.Dominio.Atividades.Entity;

namespace InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface
{
    public interface IServicoDeJwt
    {
        string GerarToken(Aluno aluno);
    }
}

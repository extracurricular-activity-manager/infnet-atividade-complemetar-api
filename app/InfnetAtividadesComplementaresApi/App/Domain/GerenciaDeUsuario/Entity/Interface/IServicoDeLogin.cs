using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;

namespace InfnetAtividadesComplementaresApi.App.Domain.GerenciaDeUsuario.Entity.Interface
{
    public interface IServicoDeLogin
    {
        string GerarToken(Aluno aluno);
        (Aluno, string) Autenticar(string documento);
    }
}

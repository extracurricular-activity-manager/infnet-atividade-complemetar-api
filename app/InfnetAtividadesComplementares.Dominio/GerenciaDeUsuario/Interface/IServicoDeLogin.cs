using InfnetAtividadesComplementares.Dominio.Atividades.Entity;

namespace InfnetAtividadesComplementares.Dominio.GerenciaDeUsuario.Interface
{
    public interface IServicoDeLogin
    {
        string GerarToken(Aluno aluno);
        (Aluno, string) Autenticar(string documento);
    }
}

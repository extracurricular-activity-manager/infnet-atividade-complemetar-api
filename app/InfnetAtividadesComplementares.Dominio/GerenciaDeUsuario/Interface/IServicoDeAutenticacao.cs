using InfnetAtividadesComplementares.Dominio.Atividades.Entity;

namespace InfnetAtividadesComplementares.Servicos.AuthService
{
    public interface IServicoDeAutenticacao
    {
        (Aluno, string) Autenticar(string documento);
    }
}

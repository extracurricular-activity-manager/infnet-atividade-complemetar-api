using InfnetAtividadesComplementares.Dominio.Dto;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Interface
{
    public interface IRepositorioDeConcessao
    {
        Task<ConcessaoDto> ObterConcessoesPor(int ano, int cursoId);
    }
}

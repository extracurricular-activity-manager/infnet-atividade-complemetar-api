using InfnetAtividadesComplementares.Dominio.Atividades.ValueObject;
using InfnetAtividadesComplementares.Dominio.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Interface
{
    public interface IRepositorioDeAtividade
    {
        Task<IEnumerable<AtividadeSheetsDto>> ObterAtividadesPor(Documento documento);
    }
}

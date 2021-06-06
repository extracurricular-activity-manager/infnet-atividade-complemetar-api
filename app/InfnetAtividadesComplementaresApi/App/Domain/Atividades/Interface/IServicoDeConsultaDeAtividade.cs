using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using System.Collections.Generic;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.Interface
{
    public interface IServicoDeConsultaDeAtividade
    {
        IList<Atividade> ObterTodasPor(string documento);
    }
}

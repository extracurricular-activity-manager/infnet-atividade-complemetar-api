using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using System.Collections.Generic;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Interface
{
    public interface IServicoDeConsultaDeHoras
    {
        Dictionary<RegraDeConcessao, int> ObterPor(string documento);
    }
}

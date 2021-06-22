using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using System.Collections.Generic;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Interface
{
    public interface IServicoDeConsultaDeAtividade
    {
        IList<Atividade> ObterTodasPor(string documento);
    }
}

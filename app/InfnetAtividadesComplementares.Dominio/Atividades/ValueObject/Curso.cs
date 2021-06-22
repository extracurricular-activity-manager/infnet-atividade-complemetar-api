using InfnetAtividadesComplementares.Dominio.Atividades.Entity;
using System.Collections.Generic;
using System.Linq;

namespace InfnetAtividadesComplementares.Dominio.Atividades.ValueObject
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int HorasExigidas { get; set; }

        public List<RegraDeConcessao> RegrasDeConcessao { get; set; }

        public Curso()
        {
            RegrasDeConcessao = new List<RegraDeConcessao>();
        }

        public RegraDeConcessao ObterRegraPor(long id)
        {
            return RegrasDeConcessao.FirstOrDefault(regra => regra.RegraDeConcessaoId == id);
        }
    }
}

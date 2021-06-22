using InfnetAtividadesComplementares.Dominio.Atividades.Entity;

namespace InfnetAtividadesComplementares.Dominio.Atividades.ValueObject
{
    public class Revisao
    {
        public int HorasSolicitadas { get; set; }
        public string Justificativa { get; set; }
        public Avaliacao AvaliacaoDaRevisao { get; set; }

    }
}

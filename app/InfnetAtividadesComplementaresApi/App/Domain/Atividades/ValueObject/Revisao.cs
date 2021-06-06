using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject
{
    public class Revisao
    {
        public int HorasSolicitadas { get; set; }
        public string Justificativa { get; set; }
        public Avaliacao AvaliacaoDaRevisao { get; set; }

    }
}

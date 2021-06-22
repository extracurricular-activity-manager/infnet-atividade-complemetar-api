using System;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Entity
{
    public class Avaliacao
    {
        public int HorasConcedidas { get; set; }
        public DateTime DataDaAvaliacao { get; set; }
        public string Observacao { get; set; }
        public string NomeDoAvaliador { get; set; }
        public bool Revisao { get; set; }
    }
}

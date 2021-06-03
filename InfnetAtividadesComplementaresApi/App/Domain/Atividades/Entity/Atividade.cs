using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Enum;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject;
using System;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity
{
    public class Atividade
    {
        public DateTime DataDaAtividade { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public DateTime CodigoSequencial { get; set; }
        public TipoComprovacaoEnum TipoDeComprovacao { get; set; }
        public string TipoDeComprovacaoOutros { get; set; }
        public int HorasSolicitadas { get; set; }
        public string JustificativaDaSolicitacao { get; set; }
        public string JustificativaDaRevisao { get; set; }
        public int HorasSolicitadasRevisao { get; set; }
        public Aluno Aluno { get; set; }
        public Categoria Categoria { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public Revisao Revisao { get; set; }


        public Atividade()
        {

        }
    }
}

using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Enum;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject;
using System;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity
{
    public class Atividade
    {
        public DateTime DataDaAtividade { get; set; }
        public DateTime DataDaSolicitacao { get; set; }
        public int CodigoSequencial { get; set; }
        public TipoComprovacaoEnum TipoDeComprovacao { get; set; }
        public string TipoDeComprovacaoDescricao { get; set; }
        public int HorasSolicitadas { get; set; }
        public string JustificativaDaSolicitacao { get; set; }
        public string Observacoes { get; set; }
        public Aluno Aluno { get; set; }
        public RegraDeConcessao RegraDeConcessao { get; set; }
        public Avaliacao Avaliacao { get; set; }
        public Revisao Revisao { get; set; }


        public Atividade()
        {

        }
    }
}

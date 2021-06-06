using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Enum;
using System;

namespace InfnetAtividadesComplementaresApi.App.Application.ConsultaDeAtividade
{
    public class DetalheDeAtividadeView
    {
        public int LimiteDeHoras { get; set; }
        public int HorasSolicitadas { get; set; }
        public int? HorasConcedidas { get; set; }
        public int CodigoSequencial { get; set; }
        public DateTime DataDaRequisicao { get; set; }
        public string Graduacao { get; set; }
        public string TipoDeAtividade { get; set; }
        public DateTime DataDaAtividade { get; set; }
        public string Comprovacao { get; set; }
        public string DefesaPeloAluno { get; set; }
        public string RegraDeConcessao { get; set; }
        public string ItemSolicitado { get; set; }
        public DateTime? DataDaAnalise { get; set; }
        public string Observacoes { get; set; }
        public string AnalisePor { get; set; }
        public string Justificativa { get; set; }
        public string ObservacoesPeloRevisor { get; set; }

        public DetalheDeAtividadeView(Atividade atividade)
        {
            LimiteDeHoras = atividade.RegraDeConcessao.LimiteDeHoras;
            HorasSolicitadas = atividade.HorasSolicitadas;
            HorasConcedidas = atividade.Avaliacao?.HorasConcedidas;
            CodigoSequencial = atividade.CodigoSequencial;
            DataDaRequisicao = atividade.DataDaSolicitacao;
            Graduacao = atividade.Aluno?.Curso?.Nome;
            Comprovacao = atividade.TipoDeComprovacao == TipoComprovacaoEnum.Outro
                ? atividade.TipoDeComprovacaoDescricao
                : atividade.TipoDeComprovacaoDescricao.ToString();
            DataDaAtividade = atividade.DataDaAtividade;
            DefesaPeloAluno = atividade.JustificativaDaSolicitacao;
            TipoDeAtividade = atividade.RegraDeConcessao.DescricaoDaAtividade;
            RegraDeConcessao = atividade.RegraDeConcessao.DescricaoRegraDeConcessao;
            ItemSolicitado = atividade.RegraDeConcessao.Item;
            Justificativa = atividade.JustificativaDaSolicitacao;
            Observacoes = atividade.Observacoes;

            if (atividade.Avaliacao != null)
            {
                DataDaAnalise = atividade.Avaliacao.DataDaAvaliacao;
                AnalisePor = atividade.Avaliacao.NomeDoAvaliador;
                ObservacoesPeloRevisor = atividade.Avaliacao.Observacao;
            }

        }
    }
}

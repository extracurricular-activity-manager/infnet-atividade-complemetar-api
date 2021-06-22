namespace InfnetAtividadesComplementares.Dominio.Atividades.Entity
{
    public class RegraDeConcessao
    {
        public long RegraDeConcessaoId { get; set; }
        public string Item { get; set; }
        public int LimiteDeHoras { get; set; }
        public string DescricaoRegraDeConcessao { get; set; }
        public string DescricaoDaAtividade { get; set; }

    }
}

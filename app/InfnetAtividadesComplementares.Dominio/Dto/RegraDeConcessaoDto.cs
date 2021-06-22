using System.Runtime.Serialization;

namespace InfnetAtividadesComplementares.Dominio.Dto
{
    [DataContract]
    public class RegraDeConcessaoDto
    {
        [DataMember(Name = "cursoId")]
        public long CursoId { get; set; }
        [DataMember(Name = "LimiteDeHoras")]
        public string DescricaoDaRegra { get; set; }
        [DataMember(Name = "limiteDeHoras")]
        public int LimiteDeHoras { get; set; }
        [DataMember(Name = "descricaoDaAtividade")]
        public string DescricaoDaAtividade { get; set; }
        [DataMember(Name = "classificacaoDaAtividade")]
        public string ClassificacaoDaAtividade { get; set; }
    }
}

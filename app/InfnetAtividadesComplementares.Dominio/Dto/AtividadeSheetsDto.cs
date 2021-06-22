using System;
using System.Runtime.Serialization;

namespace InfnetAtividadesComplementares.Dominio.Dto
{
    [DataContract]
    public class AtividadeSheetsDto
    {
        [DataMember(Name = "codigoSequencial")]
        public int CodigoSequencial { get; set; }
        [DataMember(Name = "dataRequisicao")]
        public DateTime? DataRequisicao { get; set; }
        [DataMember(Name = "graduacao")]
        public string Graduacao { get; set; }
        [DataMember(Name = "tipoDeAtividade")]
        public string TipoDeAtividade { get; set; }
        [DataMember(Name = "dataDaAtividade")]
        public DateTime? DataDaAtividade { get; set; }
        [DataMember(Name = "comprovacao")]
        public string Comprovacao { get; set; }
        [DataMember(Name = "horasSolicitadas")]
        public int HorasSolicitadas { get; set; }
        [DataMember(Name = "defesaPeloAluno")]
        public string DefesaPeloAluno { get; set; }
        [DataMember(Name = "regrasDeConcessao")]
        public string RegrasDeConcessao { get; set; }
        [DataMember(Name = "limiteDeHoras")]
        public int LimiteDeHoras { get; set; }
        [DataMember(Name = "itemSolicitado")]
        public string ItemSolicitado { get; set; }
        [DataMember(Name = "dataDaAnalise")]
        public DateTime? DataDaAnalise { get; set; }
        [DataMember(Name = "horasConcedidas")]
        public int HorasConcedidas { get; set; }
    }
}

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace InfnetAtividadesComplementares.Dominio.Dto
{
    [DataContract]
    public class ConcessaoDto
    {
        [DataMember(Name = "ano")]
        public int Ano { get; set; }
        [DataMember(Name = "regras")]
        public IList<RegraDeConcessaoDto> Regras { get; set; }

        public ConcessaoDto()
        {
            Regras = new List<RegraDeConcessaoDto>();
        }
    }
}

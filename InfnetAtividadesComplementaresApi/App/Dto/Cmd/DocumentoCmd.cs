using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetAtividadesComplementaresApi.App.Dto.Cmd
{
    [DataContract]
    public class DocumentoCmd
    {
        [DataMember(Name = "Documento")]
        [Required(ErrorMessage = "Documento é obrigatório", ErrorMessageResourceName = "Documento")]
        public string Documento { get; set; }

    }
}

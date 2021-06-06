using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace InfnetAtividadesComplementaresApi.App.Application.Login
{
    [DataContract]
    public class LoginCmd
    {
        [Required]
        [DataMember(Name = "documento")]
        public string Documento { get; set; }
    }
}

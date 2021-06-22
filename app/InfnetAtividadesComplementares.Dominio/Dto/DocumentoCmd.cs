using System.ComponentModel.DataAnnotations;

namespace InfnetAtividadesComplementares.Dominio.Dto
{
    public class DocumentoCmd
    {
        [Required(ErrorMessage = "Documento é obrigatório")]
        public string Documento { get; set; }

    }
}

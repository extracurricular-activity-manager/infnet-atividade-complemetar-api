using System.ComponentModel.DataAnnotations;

namespace InfnetAtividadesComplementaresApi.App.Dto.Cmd
{
    public class DocumentoCmd
    {
        [Required(ErrorMessage = "Documento é obrigatório")]
        public string Documento { get; set; }

    }
}

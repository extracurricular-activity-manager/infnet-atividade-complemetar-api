using InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity
{
    public class Aluno
    {
        public Documento Documento { get; set; }
        public string Matricula { get; set; }
        public int TotalHorasRealizadas { get; set; }
        public int AnoDeConcessao { get; set; }
    }
}

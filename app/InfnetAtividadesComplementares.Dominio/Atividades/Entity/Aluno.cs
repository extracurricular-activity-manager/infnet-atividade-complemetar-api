using InfnetAtividadesComplementares.Dominio.Atividades.ValueObject;

namespace InfnetAtividadesComplementares.Dominio.Atividades.Entity
{
    public class Aluno
    {
        public Documento Documento { get; set; }
        public string Matricula { get; set; }
        public int TotalHorasRealizadas { get; set; }
        public int AnoDeConcessao { get; set; }
        public string Nome { get; set; }

        public Curso Curso { get; set; }
    }
}

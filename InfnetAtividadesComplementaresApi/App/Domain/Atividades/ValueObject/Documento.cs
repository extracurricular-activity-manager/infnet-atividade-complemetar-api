using System;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.ValueObject
{
    public class Documento
    {
        private string Valor;

        public Documento(string valor)
        {
            //validar valor 
            this.Valor = valor?.Replace(".", "").Replace("-", "") ?? throw new ArgumentNullException(nameof(Documento));

            Valor = valor;
        }

        public string ValorFormatadoCpf()
        {
            return Convert.ToInt64(this.Valor).ToString(@"000\.000\.000\-00");
        }
    }
}

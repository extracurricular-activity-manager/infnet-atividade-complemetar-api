using System;

namespace InfnetAtividadesComplementares.Dominio.Atividades.ValueObject
{
    public class NomeCompleto
    {
        private string Nome;
        private string Sobrenome;

        public NomeCompleto(string nome, string sobrenome)
        {
            this.Nome = string.IsNullOrWhiteSpace(nome)
                ? throw new ArgumentNullException(nameof(NomeCompleto))
                : nome;

            this.Sobrenome = string.IsNullOrWhiteSpace(sobrenome)
                ? throw new ArgumentNullException(nameof(NomeCompleto))
                : sobrenome;

            Nome = nome;
            Sobrenome = sobrenome;
        }

        public override string ToString()
        {
            return $"{Nome} {Sobrenome}";
        }
    }
}

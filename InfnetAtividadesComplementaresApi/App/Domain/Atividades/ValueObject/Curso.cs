using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfnetAtividadesComplementaresApi.Domain.Atividades.ValueObject
{
    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public int HorasExigidas { get; set; }
    }
}

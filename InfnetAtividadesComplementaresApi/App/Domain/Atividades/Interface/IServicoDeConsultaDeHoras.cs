﻿using InfnetAtividadesComplementaresApi.App.Domain.Atividades.Entity;
using System.Collections.Generic;

namespace InfnetAtividadesComplementaresApi.App.Domain.Atividades.Interface
{
    public interface IServicoDeConsultaDeHoras
    {
        Dictionary<Categoria, int> ObterPor(string documento);
    }
}

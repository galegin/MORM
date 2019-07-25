﻿using MORM.Dominio.Entidades;
using MORM.Dominio.Interfaces;
using MORM.Servico.Models;

namespace MORM.Servico.Interfaces
{
    public interface IAmbienteAppService : IAbstractAppService<Ambiente>
    {
        object Validar(ValidarAmbienteInModel model);
    }
}
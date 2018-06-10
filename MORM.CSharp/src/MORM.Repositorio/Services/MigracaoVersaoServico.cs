﻿using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;

namespace MORM.Repositorio.Services
{
    //-- galeg - 31/03/2018 12:00:47
    public class MigracaoVersaoService : AbstractService<MigracaoVersao>
    {
        public MigracaoVersaoService(IAmbiente ambiente) : base(ambiente)
        {
        }
    }
}
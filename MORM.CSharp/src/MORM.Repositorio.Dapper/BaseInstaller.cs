﻿using MORM.CrossCutting;
using MORM.Repositorio.Dapper.Context;

namespace MORM.Repositorio.Dapper
{
    public static class BaseInstaller
    {
        public static void AddRepositorioDapper(this IAbstractContainer container)
        {
            container.Register<IAbstractDataContextDapper, AbstractDataContextDapper>();
        }
    }
}
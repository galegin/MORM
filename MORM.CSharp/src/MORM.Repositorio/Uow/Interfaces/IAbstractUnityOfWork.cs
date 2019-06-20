﻿using MORM.Repositorio.Interfaces;
using MORM.Dominio.Interfaces;

namespace MORM.Repositorio.Uow
{
    public interface IAbstractUnityOfWork
    {
        IAbstractDataContext DataContext { get; }
        void SetAmbiente(IAmbiente ambiente);
    }

    public interface IAbstracAmbtUnityOfWork
    {
        IAmbiente Ambiente { get; }
    }
}
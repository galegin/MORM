using System;

namespace MORM.CrossCutting
{
    public interface IRegisterClasse
    {
        Type IClasse { get; }
        Type Classe { get; }
        RegisterTipo Tipo { get; }
    }
}
using System;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractEntidade
    {
    }

    public interface IAbstractEntidadeId
    {
        string Id { get; set; }
    }

    public interface IAbstractEntidadeVersion
    {
        string U_Version { get; set; }
    }

    public interface IAbstractEntidadeUpdate
    {
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
    }
}
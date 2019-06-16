using System;

namespace MORM.Dominio.Interfaces
{
    public interface IAbstractEntidade
    {
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
    }
}
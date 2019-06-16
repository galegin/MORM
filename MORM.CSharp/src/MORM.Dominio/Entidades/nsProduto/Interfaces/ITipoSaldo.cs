using System;

namespace MORM.Dominio.Interfaces
{
    public interface ITipoSaldo
    {
        int Id_TipoSaldo { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_TipoSaldo { get; set; }
        string Ds_TipoSaldo { get; set; }
    }
}

using System;

namespace MORM.Dominio.Interfaces
{
    public interface ITipoValor
    {
        int Id_TipoValor { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_TipoValor { get; set; }
        string Ds_TipoValor { get; set; }
    }
}

using System;

namespace MORM.CrossCutting
{
    public interface IGrupoEmpresa
    {
        int Id_GrupoEmpresa { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_GrupoEmpresa { get; set; }
        string Nm_GrupoEmpresa { get; set; }
    }
}
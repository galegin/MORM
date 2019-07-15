using System;

namespace MORM.Dominio.Interfaces
{
    public interface IEmpresa
    {
        int Id_Empresa { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_GrupoEmpresa { get; set; }
        string Cd_Empresa { get; set; }
        string Ds_Empresa { get; set; }
    }
}
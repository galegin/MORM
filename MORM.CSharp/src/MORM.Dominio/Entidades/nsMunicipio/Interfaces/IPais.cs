using System;

namespace MORM.Dominio.Interfaces
{
    public interface IPais
    {
        int Id_Pais { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Nm_Pais { get; set; }
        string Ds_Sigla { get; set; }
    }
}
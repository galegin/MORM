using System;

namespace MORM.Dominio.Interfaces
{
    public interface IEstado
    {
        int Id_Estado { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Pais { get; set; }
        string Cd_Estado { get; set; }
        string Nm_Estado { get; set; }
        string Ds_Sigla { get; set; }

        IPais Pais { get; set; }
    }
}
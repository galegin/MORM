using System;

namespace MORM.Dominio.Interfaces
{
    public interface IMunicipio
    {
        int Id_Municipio { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Estado { get; set; }
        string Cd_Municipio { get; set; }
        string Nm_Municipio { get; set; }
        string Ds_Sigla { get; set; }

        IEstado Estado { get; set; }
    }
}
using System;

namespace MORM.Dominio.Interfaces
{
    public interface IBairro
    {
        int Id_Bairro { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Ds_Bairro { get; set; }
    }
}
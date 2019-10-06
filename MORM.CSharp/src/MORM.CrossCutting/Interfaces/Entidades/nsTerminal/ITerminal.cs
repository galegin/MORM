using System;

namespace MORM.CrossCutting
{
    public interface ITerminal
    {
        int Id_Terminal { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_Terminal { get; set; }
        string Ds_Terminal { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public interface IRegraFiscal
    {
        int Id_RegraFiscal { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_RegraFiscal { get; set; }
        string Ds_RegraFiscal { get; set; }
        int Cd_CfopEntrada { get; set; }
        int Cd_CfopSaida { get; set; }

        ICollection<IRegraFiscalImposto> Impostos { get; set; }
    }
}
using System;

namespace MORM.Dominio.Interfaces
{
    public interface IRegraFiscalImposto
    {
        int Id_RegraFiscalImposto { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_RegraFiscal { get; set; }
        int Id_Imposto { get; set; }
        double Pr_Aliquota { get; set; }
        string Cd_Cst { get; set; }
        string Cd_Cest { get; set; }
        string Cd_Csosn { get; set; }
    }
}
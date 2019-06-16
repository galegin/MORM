using System;

namespace MORM.Dominio.Interfaces
{
    public enum TipoImposto
    {
        Icms = 1,
        IcmsSt = 2,
        Pis = 3,
        Cofins = 4,
        Issqn = 5,
        Ipi = 6,
        Ii = 7
    }

    public interface ITransacaoItemImposto
    {
        int Id_TransacaoItemImposto { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_TransacaoItem { get; set; }
        int Id_Imposto { get; set; }
        double Vl_BaseCalculo { get; set; }
        double Pr_BaseCalculo { get; set; }
        double Pr_RedBaseCalculo { get; set; }
        double Pr_Aliquota { get; set; }
        double Vl_Imposto { get; set; }
        string Cd_Cst { get; set; }
        string Cd_Cest { get; set; }
        string Cd_Csosn { get; set; }
    }
}
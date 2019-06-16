using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public enum TipoOperacao
    {
        Entrada = 1,
        Saida = -1
    }

    public enum TipoModalidade
    {
        VendaEcf,
        VendaManual,
        VendaNfce,
        VendaNfe,
        VendaSat,
        DevolucaoManual,
        DevolucaoNfe,
    }

    public interface IOperacao
    {
        int Id_Operacao { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_RegraFiscal { get; set; }
        string Cd_Operacao { get; set; }
        string Ds_Operacao { get; set; }
        int Tp_Operacao { get; set; }
        int Tp_Modalidade { get; set; }
        bool In_GerarFinanceiro { get; set; }
        bool In_GerarFiscal { get; set; }
        bool In_GerarSaldo { get; set; }

        IRegraFiscal RegraFiscal { get; set; }
        ICollection<IOperacaoSaldo> Saldos { get; set; }
        ICollection<IOperacaoValor> Valores { get; set; }
    }
}
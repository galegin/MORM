using System;

namespace MORM.Dominio.Interfaces
{
    public enum TipoDocumento
    {
        Dinheiro,
        CartaoDeCredito,
        CartaoDeDebito,
        Crediario,
        Cheque,
        Tef,
        Troco,
    }

    public interface ITransacaoPagto
    {
        int Id_TransacaoPagto { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Transacao { get; set; }
        int Tp_Documento { get; set; }
        int Nr_Documento { get; set; }
        DateTime Dt_Vencimento { get; set; }
        double Vl_Documento { get; set; }
        int Qt_Parcela { get; set; }
        int Nr_Parcela { get; set; }
        string Cd_Autorizacao { get; set; }
        string Nr_Nsu { get; set; }
        string Ds_Operadora { get; set; }
        string Ds_Bandeira { get; set; }
        int Nr_Banco { get; set; }
        int Nr_Agencia { get; set; }
        int Nr_Conta { get; set; }
        int Nr_Cheque { get; set; }
        string Ds_Banda { get; set; }
    }
}
using System;

namespace MORM.Dominio.Interfaces
{
    public enum TipoProcessamento
    {
        Gerada,
        Autorizada,
        Enviada,
        Inutilizadda,
        Cancelada
    }

    public enum SituacaoFiscal
    {
        Normal,
        Emitida,
        Cancelada,
        Excluida
    }

    public interface ITransacaoFiscal
    {
        int Id_TransacaoFiscal { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Transacao { get; set; }
        int Tp_DocumentoFiscal { get; set; }
        int Nr_Documento { get; set; }
        int Nr_DocumentoCanc { get; set; }
        int Nr_DocumentoManual { get; set; }
        int Tp_SituacaoFiscal { get; set; }
        int Tp_Processamento { get; set; }
        string Cd_SerieFiscal { get; set; }
        string Cd_SerieFabricante { get; set; }
        string Cd_ChaveAcesso { get; set; }
        string Cd_ChaveAcessoCanc { get; set; }
        DateTime Dt_Emissao { get; set; }
        DateTime Dt_Cancelamento { get; set; }
        DateTime Dt_Recibo { get; set; }
        string Nr_Recibo { get; set; }
    }
}
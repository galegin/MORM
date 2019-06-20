using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO_FISCAL")]
    public class TransacaoFiscal : ITransacaoFiscal
    {
        [Campo("ID_TRANSACAOFISCAL", CampoTipo.Key)]
        public int Id_TransacaoFiscal { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_TRANSACAO", CampoTipo.Req)]
        public int Id_Transacao { get; set; }
        [Campo("TP_DOCUMENTOFISCAL", CampoTipo.Req)]
        public int Tp_DocumentoFiscal { get; set; }
        [Campo("NR_DOCUMENTO", CampoTipo.Req)]
        public int Nr_Documento { get; set; }
        [Campo("NR_DOCUMENTOCANC", CampoTipo.Nul)]
        public int Nr_DocumentoCanc { get; set; }
        [Campo("NR_DOCUMENTOMANUAL", CampoTipo.Nul)]
        public int Nr_DocumentoManual { get; set; }
        [Campo("TP_SITUACAOFISCAL", CampoTipo.Req)]
        public int Tp_SituacaoFiscal { get; set; }
        [Campo("TP_PROCESSAMENTO", CampoTipo.Req)]
        public int Tp_Processamento { get; set; }
        [Campo("CD_SERIEFISCAL", CampoTipo.Req)]
        public string Cd_SerieFiscal { get; set; }
        [Campo("CD_SERIEFABRICANTE", CampoTipo.Nul)]
        public string Cd_SerieFabricante { get; set; }
        [Campo("CD_CHAVEACESSO", CampoTipo.Nul)]
        public string Cd_ChaveAcesso { get; set; }
        [Campo("CD_CHAVEACESSOCANC", CampoTipo.Nul)]
        public string Cd_ChaveAcessoCanc { get; set; }
        [Campo("DT_EMISSAO", CampoTipo.Nul)]
        public DateTime Dt_Emissao { get; set; }
        [Campo("DT_CANCELAMENTO", CampoTipo.Nul)]
        public DateTime Dt_Cancelamento { get; set; }
        [Campo("DT_RECIBO", CampoTipo.Nul)]
        public DateTime Dt_Recibo { get; set; }
        [Campo("NR_RECIBO", CampoTipo.Nul)]
        public string Nr_Recibo { get; set; }
    }
}
using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSPAGTO")]
    public class Transpagto : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("NR_SEQ", CampoTipo.Key)]
        public int Nr_Seq { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_CAIXA", CampoTipo.Req)]
        public int Id_Caixa { get; set; }
        [Campo("TP_DOCUMENTO", CampoTipo.Req)]
        public int Tp_Documento { get; set; }
        [Campo("ID_HISTREL", CampoTipo.Req)]
        public int Id_Histrel { get; set; }
        [Campo("NR_PARCELA", CampoTipo.Req)]
        public int Nr_Parcela { get; set; }
        [Campo("NR_PARCELAS", CampoTipo.Req)]
        public int Nr_Parcelas { get; set; }
        [Campo("NR_DOCUMENTO", CampoTipo.Nul)]
        public int Nr_Documento { get; set; }
        [Campo("VL_DOCUMENTO", CampoTipo.Req)]
        public double Vl_Documento { get; set; }
        [Campo("DT_VENCIMENTO", CampoTipo.Req)]
        public DateTime Dt_Vencimento { get; set; }
        [Campo("CD_AUTORIZACAO", CampoTipo.Nul)]
        public string Cd_Autorizacao { get; set; }
        [Campo("NR_NSU", CampoTipo.Nul)]
        public int Nr_Nsu { get; set; }
        [Campo("DS_REDETEF", CampoTipo.Nul)]
        public string Ds_Redetef { get; set; }
        [Campo("NM_OPERADORA", CampoTipo.Nul)]
        public string Nm_Operadora { get; set; }
        [Campo("NR_BANCO", CampoTipo.Nul)]
        public int Nr_Banco { get; set; }
        [Campo("NR_AGENCIA", CampoTipo.Nul)]
        public int Nr_Agencia { get; set; }
        [Campo("DS_CONTA", CampoTipo.Nul)]
        public string Ds_Conta { get; set; }
        [Campo("NR_CHEQUE", CampoTipo.Nul)]
        public int Nr_Cheque { get; set; }
        [Campo("DS_CMC7", CampoTipo.Nul)]
        public string Ds_Cmc7 { get; set; }
        [Campo("TP_BAIXA", CampoTipo.Nul)]
        public int Tp_Baixa { get; set; }
        [Campo("CD_OPERBAIXA", CampoTipo.Nul)]
        public int Cd_Operbaixa { get; set; }
        [Campo("DT_BAIXA", CampoTipo.Nul)]
        public DateTime Dt_Baixa { get; set; }
    }
}
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSFISCAL")]
    public class Transfiscal : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("TP_OPERACAO", CampoTipo.Req)]
        public int Tp_Operacao { get; set; }
        [Campo("TP_MODALIDADE", CampoTipo.Req)]
        public int Tp_Modalidade { get; set; }
        [Campo("TP_MODELONF", CampoTipo.Req)]
        public int Tp_Modelonf { get; set; }
        [Campo("CD_SERIE", CampoTipo.Req)]
        public string Cd_Serie { get; set; }
        [Campo("NR_NF", CampoTipo.Req)]
        public int Nr_Nf { get; set; }
        [Campo("TP_PROCESSAMENTO", CampoTipo.Req)]
        public string Tp_Processamento { get; set; }
        [Campo("DS_CHAVEACESSO", CampoTipo.Nul)]
        public string Ds_Chaveacesso { get; set; }
        [Campo("DT_RECEBIMENTO", CampoTipo.Nul)]
        public DateTime Dt_Recebimento { get; set; }
        [Campo("NR_RECIBO", CampoTipo.Nul)]
        public string Nr_Recibo { get; set; }
    }
}
using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TRANSIMPOSTO")]
    public class Transimposto : CollectionItem
    {
        [Campo("ID_TRANSACAO", CampoTipo.Key)]
        public string Id_Transacao { get; set; }
        [Campo("NR_ITEM", CampoTipo.Key)]
        public int Nr_Item { get; set; }
        [Campo("CD_IMPOSTO", CampoTipo.Key)]
        public int Cd_Imposto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("PR_ALIQUOTA", CampoTipo.Req)]
        public double Pr_Aliquota { get; set; }
        [Campo("VL_BASECALCULO", CampoTipo.Req)]
        public double Vl_Basecalculo { get; set; }
        [Campo("PR_BASECALCULO", CampoTipo.Req)]
        public double Pr_Basecalculo { get; set; }
        [Campo("PR_REDBASECALCULO", CampoTipo.Req)]
        public double Pr_Redbasecalculo { get; set; }
        [Campo("VL_IMPOSTO", CampoTipo.Req)]
        public double Vl_Imposto { get; set; }
        [Campo("VL_OUTRO", CampoTipo.Req)]
        public double Vl_Outro { get; set; }
        [Campo("VL_ISENTO", CampoTipo.Req)]
        public double Vl_Isento { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("CD_CSOSN", CampoTipo.Nul)]
        public string Cd_Csosn { get; set; }
    }
}
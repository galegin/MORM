using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("REGRAIMPOSTO")]
    public class Regraimposto : CollectionItem
    {
        [Campo("ID_REGRAFISCAL", CampoTipo.Key)]
        public int Id_Regrafiscal { get; set; }
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
        [Campo("PR_BASECALCULO", CampoTipo.Req)]
        public double Pr_Basecalculo { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("CD_CSOSN", CampoTipo.Nul)]
        public string Cd_Csosn { get; set; }
        [Campo("IN_ISENTO", CampoTipo.Req)]
        public string In_Isento { get; set; }
        [Campo("IN_OUTRO", CampoTipo.Req)]
        public string In_Outro { get; set; }
    }
}
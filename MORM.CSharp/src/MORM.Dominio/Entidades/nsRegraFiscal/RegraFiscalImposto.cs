using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("REGRA_FISCAL_IMPOSTO")]
    public class RegraFiscalImposto : IRegraFiscalImposto
    {
        [Campo("ID_", CampoTipo.Key)]
        public int Id_RegraFiscalImposto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_REGRAFISCAL", CampoTipo.Req)]
        public int Id_RegraFiscal { get; set; }
        [Campo("ID_IMPOSTO", CampoTipo.Req)]
        public int Id_Imposto { get; set; }
        [Campo("PR_ALIQUOTA", CampoTipo.Req)]
        public double Pr_Aliquota { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("CD_CEST", CampoTipo.Req)]
        public string Cd_Cest { get; set; }
        [Campo("CD_CSOSN", CampoTipo.Req)]
        public string Cd_Csosn { get; set; }
    }
}
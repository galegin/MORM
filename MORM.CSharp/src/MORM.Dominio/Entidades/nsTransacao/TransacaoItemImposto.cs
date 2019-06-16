using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO_ITEM_IMPOSTO")]
    public class TransacaoItemImposto : ITransacaoItemImposto
    {
        [Campo("ID_TRANSACAOITEMIMPOSTO", CampoTipo.Key)]
        public int Id_TransacaoItemImposto { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_TRANSACAOITEM", CampoTipo.Req)]
        public int Id_TransacaoItem { get; set; }
        [Campo("ID_IMPOSTO", CampoTipo.Req)]
        public int Id_Imposto { get; set; }
        [Campo("VL_BASECALCULO", CampoTipo.Req)]
        public double Vl_BaseCalculo { get; set; }
        [Campo("PR_BASECALCULO", CampoTipo.Req)]
        public double Pr_BaseCalculo { get; set; }
        [Campo("PR_REDBASECALCULO", CampoTipo.Req)]
        public double Pr_RedBaseCalculo { get; set; }
        [Campo("PR_ALIQUOTA", CampoTipo.Req)]
        public double Pr_Aliquota { get; set; }
        [Campo("VL_IMPOSTO", CampoTipo.Req)]
        public double Vl_Imposto { get; set; }
        [Campo("CD_CST", CampoTipo.Req)]
        public string Cd_Cst { get; set; }
        [Campo("CD_CEST", CampoTipo.Req)]
        public string Cd_Cest { get; set; }
        [Campo("CD_CSOSN", CampoTipo.Req)]
        public string Cd_Csosn { get; set; }
    }
}
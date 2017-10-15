using MORM.CSharp.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("CAIXAMOV")]
    public class Caixamov : CollectionItem
    {
        [Campo("ID_CAIXA", CampoTipo.Key)]
        public int Id_Caixa { get; set; }
        [Campo("NR_SEQ", CampoTipo.Key)]
        public int Nr_Seq { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("TP_LANCTO", CampoTipo.Req)]
        public int Tp_Lancto { get; set; }
        [Campo("VL_LANCTO", CampoTipo.Req)]
        public double Vl_Lancto { get; set; }
        [Campo("NR_DOC", CampoTipo.Req)]
        public int Nr_Doc { get; set; }
        [Campo("DS_AUX", CampoTipo.Req)]
        public string Ds_Aux { get; set; }
    }
}
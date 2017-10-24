using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("REGRAFISCAL")]
    public class Regrafiscal : CollectionItem
    {
        [Campo("ID_REGRAFISCAL", CampoTipo.Key)]
        public int Id_Regrafiscal { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DS_REGRAFISCAL", CampoTipo.Req)]
        public string Ds_Regrafiscal { get; set; }
        [Campo("IN_CALCIMPOSTO", CampoTipo.Req)]
        public string In_Calcimposto { get; set; }
    }
}
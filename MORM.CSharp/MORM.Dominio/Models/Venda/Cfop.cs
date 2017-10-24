using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("CFOP")]
    public class Cfop : CollectionItem
    {
        [Campo("CD_CFOP", CampoTipo.Key)]
        public int Cd_Cfop { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DS_CFOP", CampoTipo.Req)]
        public string Ds_Cfop { get; set; }
    }
}
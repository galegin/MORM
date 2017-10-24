using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("NCM")]
    public class Ncm : CollectionItem
    {
        [Campo("CD_NCM", CampoTipo.Key)]
        public string Cd_Ncm { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("DS_NCM", CampoTipo.Req)]
        public string Ds_Ncm { get; set; }
    }
}
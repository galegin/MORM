using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("TERMINAL")]
    public class Terminal : CollectionItem
    {
        [Campo("ID_TERMINAL", CampoTipo.Key)]
        public int Id_Terminal { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_TERMINAL", CampoTipo.Req)]
        public int Cd_Terminal { get; set; }
        [Campo("DS_TERMINAL", CampoTipo.Req)]
        public string Ds_Terminal { get; set; }
    }
}
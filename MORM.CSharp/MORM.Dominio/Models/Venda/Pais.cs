using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("PAIS")]
    public class Pais : CollectionItem
    {
        [Campo("ID_PAIS", CampoTipo.Key)]
        public int Id_Pais { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_PAIS", CampoTipo.Req)]
        public int Cd_Pais { get; set; }
        [Campo("DS_PAIS", CampoTipo.Req)]
        public string Ds_Pais { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }
    }
}
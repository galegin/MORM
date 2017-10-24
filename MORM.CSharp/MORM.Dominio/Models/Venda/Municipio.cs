using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("MUNICIPIO")]
    public class Municipio : CollectionItem
    {
        [Campo("ID_MUNICIPIO", CampoTipo.Key)]
        public int Id_Municipio { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_MUNICIPIO", CampoTipo.Req)]
        public int Cd_Municipio { get; set; }
        [Campo("DS_MUNICIPIO", CampoTipo.Req)]
        public string Ds_Municipio { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }
        [Campo("ID_ESTADO", CampoTipo.Req)]
        public int Id_Estado { get; set; }
    }
}
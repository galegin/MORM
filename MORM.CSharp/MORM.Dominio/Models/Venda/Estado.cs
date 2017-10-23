using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("ESTADO")]
    public class Estado : CollectionItem
    {
        [Campo("ID_ESTADO", CampoTipo.Key)]
        public int Id_Estado { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_ESTADO", CampoTipo.Req)]
        public int Cd_Estado { get; set; }
        [Campo("DS_ESTADO", CampoTipo.Req)]
        public string Ds_Estado { get; set; }
        [Campo("DS_SIGLA", CampoTipo.Req)]
        public string Ds_Sigla { get; set; }
        [Campo("ID_PAIS", CampoTipo.Req)]
        public int Id_Pais { get; set; }
    }
}
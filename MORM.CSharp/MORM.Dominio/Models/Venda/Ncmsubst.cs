using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("NCMSUBST")]
    public class Ncmsubst : CollectionItem
    {
        [Campo("UF_ORIGEM", CampoTipo.Key)]
        public string Uf_Origem { get; set; }
        [Campo("UF_DESTINO", CampoTipo.Key)]
        public string Uf_Destino { get; set; }
        [Campo("CD_NCM", CampoTipo.Key)]
        public string Cd_Ncm { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Nul)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Nul)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_CEST", CampoTipo.Nul)]
        public string Cd_Cest { get; set; }
    }
}
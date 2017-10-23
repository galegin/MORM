using MORM.Util.Atributos;
using MORM.Util.Classes;
using System;

namespace MORM.CSharp.Models
{
    [Tabela("EMPRESA")]
    public class Empresa : CollectionItem
    {
        [Campo("ID_EMPRESA", CampoTipo.Key)]
        public int Id_Empresa { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_PESSOA", CampoTipo.Req)]
        public string Id_Pessoa { get; set; }
    }
}
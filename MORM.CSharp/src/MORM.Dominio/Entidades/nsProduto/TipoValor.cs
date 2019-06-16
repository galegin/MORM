using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TIPO_VALOR")]
    public class TipoValor : ITipoValor
    {
        [Campo("ID_TIPOVALOR", CampoTipo.Key)]
        public int Id_TipoValor { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_TIPOVALOR", CampoTipo.Req)]
        public string Cd_TipoValor { get; set; }
        [Campo("DS_TIPOVALOR", CampoTipo.Req)]
        public string Ds_TipoValor { get; set; }
    }
}

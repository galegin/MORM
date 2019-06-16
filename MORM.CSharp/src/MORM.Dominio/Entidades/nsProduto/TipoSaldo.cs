using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TIPO_SALDO")]
    public class TipoSaldo : ITipoSaldo
    {
        [Campo("ID_TIPOSALDO", CampoTipo.Key)]
        public int Id_TipoSaldo { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_TIPOSALDO", CampoTipo.Req)]
        public string Cd_TipoSaldo { get; set; }
        [Campo("DS_TIPOSALDO", CampoTipo.Req)]
        public string Ds_TipoSaldo { get; set; }
    }
}

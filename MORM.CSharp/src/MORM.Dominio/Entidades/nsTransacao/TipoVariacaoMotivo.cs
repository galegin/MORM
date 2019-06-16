using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TIPO_VARIACAO_MOTIVO")]
    public class TipoVariacaoMotivo : ITipoVariacaoMotivo
    {
        [Campo("ID_", CampoTipo.Key)]
        public int Id_TipoVariacaoMotivo { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_TIPOVARIACAOMOTIVO", CampoTipo.Req)]
        public string Cd_TipoVariacaoMotivo { get; set; }
        [Campo("DS_TIPOVARIACAOMOTIVO", CampoTipo.Req)]
        public string Ds_TipoVariacaoMotivo { get; set; }
    }
}
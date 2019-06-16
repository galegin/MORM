using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TIPO_VARIACAO")]
    public class TipoVariacao : ITipoVariacao
    {
        [Campo("ID_", CampoTipo.Key)]
        public int Id_TipoVariacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("CD_TIPOVARIACAO", CampoTipo.Req)]
        public string Cd_TipoVariacao { get; set; }
        [Campo("DS_TIPOVARIACAO", CampoTipo.Req)]
        public string Ds_TipoVariacao { get; set; }
        [Campo("TP_TIPOVARIACAOVALOR", CampoTipo.Req)]
        public TipoVariacaoValor Tp_TipoVariacaoValor { get; set; }
        [Campo("TP_TIPOVARIACAOCAPA", CampoTipo.Req)]
        public TipoVariacaoCapa Tp_TipoVariacaoCapa { get; set; }
    }
}
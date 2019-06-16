using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO_ITEM_VARIACAO")]
    public class TransacaoItemVariacao : ITransacaoItemVariacao
    {
        [Campo("ID_TRANSACAOITEMVARIACAO", CampoTipo.Key)]
        public int Id_TransacaoItemVariacao { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_TRANSACAOITEM", CampoTipo.Req)]
        public int Id_TransacaoItem { get; set; }
        [Campo("ID_TIPOVARIACAO", CampoTipo.Req)]
        public int Id_TipoVariacao { get; set; }
        [Campo("ID_TIPOVARIACAOMOTIVO", CampoTipo.Req)]
        public int Id_TipoVariacaoMotivo { get; set; }
        [Campo("TP_VARIACAOVALOR", CampoTipo.Req)]
        public TipoVariacaoValor Tp_TipoVariacaoValor { get; set; }
        [Campo("TP_VARIACAOCAPA", CampoTipo.Req)]
        public TipoVariacaoCapa Tp_TipoVariacaoCapa { get; set; }
        [Campo("VL_ITEMANTERIOR", CampoTipo.Req)]
        public double Vl_ItemAnterior { get; set; }
        [Campo("VL_VARIACAOCAPA", CampoTipo.Req)]
        public double Vl_VariacaoCapa { get; set; }
        [Campo("VL_VARIACAOITEM", CampoTipo.Req)]
        public double Vl_VariacaoItem { get; set; }
        [Campo("VL_ITEMATUAL", CampoTipo.Req)]
        public double Vl_ItemAtual { get; set; }

        [Relacao(nameof(Id_TipoVariacao))]
        public ITipoVariacao TipoVariacao { get; set; }
        [Relacao(nameof(Id_TipoVariacaoMotivo))]
        public ITipoVariacaoMotivo TipoVariacaoMotivo { get; set; }

        public TransacaoItemVariacao()
        {
            TipoVariacao = new TipoVariacao();
            TipoVariacaoMotivo = new TipoVariacaoMotivo();
        }
    }
}
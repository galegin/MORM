using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Entidades
{
    [Tabela("TRANSACAO_ITEM")]
    public class TransacaoItem : ITransacaoItem
    {
        [Campo("ID_TRANSACAOITEM", CampoTipo.Key)]
        public int Id_TransacaoItem { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_TRANSACAO", CampoTipo.Req)]
        public int Id_Transacao { get; set; }
        [Campo("ID_PRODUTO", CampoTipo.Req)]
        public int Id_Produto { get; set; }
        [Campo("ID_PRODUTOKIT", CampoTipo.Req)]
        public int Id_ProdutoKit { get; set; }
        [Campo("ID_PRODUTOBARRA", CampoTipo.Req)]
        public int Id_ProdutoBarra { get; set; }
        [Campo("NR_SEQINCLUSAO", CampoTipo.Req)]
        public int Nr_SeqInclusao { get; set; }
        [Campo("NR_ITEM", CampoTipo.Req)]
        public int Nr_Item { get; set; }
        [Campo("CD_ITEM", CampoTipo.Req)]
        public string Cd_Item { get; set; }
        [Campo("DS_ITEM", CampoTipo.Req)]
        public string Ds_Item { get; set; }
        [Campo("QT_ITEM", CampoTipo.Req)]
        public double Qt_Item { get; set; }
        [Campo("VL_ORIGINAL", CampoTipo.Req)]
        public double Vl_Original { get; set; }
        [Campo("VL_UNITLIQUIDO", CampoTipo.Req)]
        public double Vl_UnitLiquido { get; set; }
        [Campo("VL_UNITDESCONTO", CampoTipo.Req)]
        public double Vl_UnitDesconto { get; set; }
        [Campo("VL_UNITACRESCIMO", CampoTipo.Req)]
        public double Vl_UnitAcrescimo { get; set; }
        [Campo("VL_UNITBRUTO", CampoTipo.Req)]
        public double Vl_UnitBruto { get; set; }
        [Campo("VL_TOTALLIQUIDO", CampoTipo.Req)]
        public double Vl_TotalLiquido { get; set; }
        [Campo("VL_TOTALDESCONTO", CampoTipo.Req)]
        public double Vl_TotalDesconto { get; set; }
        [Campo("VL_TOTALACRESCIMO", CampoTipo.Req)]
        public double Vl_TotalAcrescimo { get; set; }
        [Campo("VL_TOTALBRUTO", CampoTipo.Req)]
        public double Vl_TotalBruto { get; set; }

        [Relacao(nameof(Id_Produto))]
        public IProduto Produto { get; set; }
        [Relacao(nameof(Id_ProdutoKit))]
        public IProdutoKit ProdutoKit { get; set; }
        [Relacao(nameof(Id_ProdutoBarra))]
        public IProdutoBarra ProdutoBarra { get; set; }

        [Relacao(nameof(Id_TransacaoItem), RelacaoTipo.Update)]
        public ICollection<ITransacaoItemImposto> Impostos { get; set; }
        [Relacao(nameof(Id_TransacaoItem), RelacaoTipo.Update)]
        public ICollection<ITransacaoItemVariacao> Variacoes { get; set; }

        public TransacaoItem()
        {
            Impostos = new List<ITransacaoItemImposto>();
            Variacoes = new List<ITransacaoItemVariacao>();
        }
    }
}
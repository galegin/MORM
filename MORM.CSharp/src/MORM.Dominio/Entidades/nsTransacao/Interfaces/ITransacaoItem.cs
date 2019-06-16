using MORM.Dominio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public interface ITransacaoItem
    {
        int Id_TransacaoItem { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Transacao { get; set; }
        int Id_Produto { get; set; }
        int Id_ProdutoKit { get; set; }
        int Id_ProdutoBarra { get; set; }
        int Nr_SeqInclusao { get; set; }
        int Nr_Item { get; set; }
        string Cd_Item { get; set; }
        string Ds_Item { get; set; }
        double Qt_Item { get; set; }
        double Vl_Original { get; set; }
        double Vl_UnitLiquido { get; set; }
        double Vl_UnitDesconto { get; set; }
        double Vl_UnitAcrescimo { get; set; }
        double Vl_UnitBruto { get; set; }
        double Vl_TotalLiquido { get; set; }
        double Vl_TotalDesconto { get; set; }
        double Vl_TotalAcrescimo { get; set; }
        double Vl_TotalBruto { get; set; }

        IProduto Produto { get; set; }
        IProdutoKit ProdutoKit { get; set; }
        IProdutoBarra ProdutoBarra { get; set; }
        ICollection<ITransacaoItemImposto> Impostos { get; set; }
        ICollection<ITransacaoItemVariacao> Variacoes { get; set; }
    }
}
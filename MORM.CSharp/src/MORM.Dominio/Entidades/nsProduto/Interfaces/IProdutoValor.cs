using System;

namespace MORM.Dominio.Interfaces
{
    public interface IProdutoValor
    {
        int Id_ProdutoValor { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Empresa { get; set; }
        int Id_Produto { get; set; }
        int Id_TipoValor { get; set; }
        DateTime Dt_Valor { get; set; }
        double Vl_Produto { get; set; }

        IEmpresa Empresa { get; set; }
        IProduto Produto { get; set; }
        ITipoValor TipoValor { get; set; }
    }
}

using System;

namespace MORM.Dominio.Interfaces
{
    public interface IProdutoSaldo
    {
        int Id_ProdutoSaldo { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Empresa { get; set; }
        int Id_Produto { get; set; }
        int Id_TipoSaldo { get; set; }
        DateTime Dt_Saldo { get; set; }
        double Qt_Saldo { get; set; }
        double Vl_Saldo { get; set; }

        IEmpresa Empresa { get; set; }
        IProduto Produto { get; set; }
        ITipoSaldo TipoSaldo { get; set; }
    }
}

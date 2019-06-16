using System;

namespace MORM.Dominio.Interfaces
{
    public interface IProdutoBarra
    {
        int Id_ProdutoBarra { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Produto { get; set; }
        string Cd_ProdutoBarra { get; set; }
        double Qt_Embalagem { get; set; }
        bool In_Padrao { get; set; }

        IProduto Produto { get; set; }
    }
}

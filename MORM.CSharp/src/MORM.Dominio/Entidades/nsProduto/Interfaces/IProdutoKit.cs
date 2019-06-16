using System;

namespace MORM.Dominio.Interfaces
{
    public interface IProdutoKit
    {
        int Id_ProdutoKit { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Kit { get; set; }
        int Id_Produto { get; set; }
        string Cd_ProdutoKit { get; set; }

        IProduto Produto { get; set; }
    }
}

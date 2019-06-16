using System;

namespace MORM.Dominio.Interfaces
{
    public interface IProduto
    {
        int Id_Produto { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Cd_Produto { get; set; }
        string Ds_Produto { get; set; }
        string Cd_Especie { get; set; }
        string Cd_Ncm { get; set; }
        string Cd_Cst { get; set; }
        bool In_FabrPropria { get; set; }
        bool In_Arredonda { get; set; }
    }
}

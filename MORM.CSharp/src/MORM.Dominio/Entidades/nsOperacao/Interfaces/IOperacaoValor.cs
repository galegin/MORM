using System;

namespace MORM.Dominio.Interfaces
{
    public interface IOperacaoValor
    {
        int Id_OperacaoValor { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Operacao { get; set; }
        int Id_TipoValor { get; set; }
        bool In_ValorPadrao { get; set; }
    }
}
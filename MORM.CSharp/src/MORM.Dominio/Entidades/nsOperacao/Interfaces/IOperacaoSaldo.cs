using System;

namespace MORM.Dominio.Interfaces
{
    public interface IOperacaoSaldo
    {
        int Id_OperacaoSaldo { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Operacao { get; set; }
        int Id_TipoSaldo { get; set; }
        bool In_GerarSaldo { get; set; }
    }
}
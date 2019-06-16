using System;

namespace MORM.Dominio.Interfaces
{
    public enum PessoaEmailTipo
    {
        Pessoal = 1,
        Trabalho,
    }

    public interface IPessoaEmail
    {
        int Id_PessoaEmail { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Pessoa { get; set; }
        int Tp_Email { get; set; }
        string Ds_Email { get; set; }
        bool In_Padrao { get; set; }
    }
}
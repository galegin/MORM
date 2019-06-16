using System;

namespace MORM.Dominio.Interfaces
{
    public enum PessoaTelefoneTipo
    {
        Pessoal = 1,
        Trabalho,
        Celular,
    }

    public interface IPessoaTelefone
    {
        int Id_PessoaTelefone { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Pessoa { get; set; }
        int Tp_Telefone { get; set; }
        string Ds_DDI { get; set; }
        string Ds_DDD { get; set; }
        string Ds_Telefone { get; set; }
        bool In_Padrao { get; set; }
    }
}
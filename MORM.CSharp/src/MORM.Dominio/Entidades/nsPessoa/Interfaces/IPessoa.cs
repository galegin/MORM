using System;
using System.Collections.Generic;

namespace MORM.Dominio.Interfaces
{
    public enum PessoaTipo
    {
        Fisica = 1,
        Juridica,
        Estrangeira
    }

    public enum PessoaTipoDocumento
    {
        Cpf = 1,
        Cnpj,
        Ctps,
        Passaporte
    }

    public enum PessoaTipoInscricao
    {
        Rg = 1, // Registro Geral
        Ie, // Inscricao Estadual (Icms)
        Im, // Inscricao Municipal (Iss)
        Isento, // Isento
    }

    public enum PessoaTipoRegimeTributario
    {
        SimplesNacional = 1,
        MicroEmpresa,
        MicroEmpreendedorIndividual,
        LucroReal,
        LucroPresumido,
    }

    public interface IPessoa
    {
        int Id_Pessoa { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        string Nm_Pessoa { get; set; }
        string Tp_Pessoa { get; set; }
        int Tp_Documento { get; set; }
        string Nr_Documento { get; set; }
        int Tp_Inscricao { get; set; }
        string Nr_Inscricao { get; set; }
        int Tp_RegimeTributario { get; set; }

        ICollection<IPessoaEmail> Emails { get; set; }
        ICollection<IPessoaEndereco> Enderecos { get; set; }
        ICollection<IPessoaTelefone> Telefones { get; set; }
    }
}
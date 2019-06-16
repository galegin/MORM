using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Interfaces
{
    public enum PessoaEnderecoTipo
    {
        Residencial = 1,
        Trabalho,
        Entrega
    }

    public interface IPessoaEndereco
    {
        int Id_PessoaEndereco { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Pessoa { get; set; }
        int Tp_Endereco { get; set; }
        string Cd_Cep { get; set; }
        string Ds_TipoLogradouro { get; set; }
        string Ds_Logradouro { get; set; }
        string Nr_Logradouro { get; set; }
        string Ds_Bairro { get; set; }
        string Ds_Complemento { get; set; }
        int Id_Municipio { get; set; }

        IMunicipio Municipio { get; set; }
    }
}
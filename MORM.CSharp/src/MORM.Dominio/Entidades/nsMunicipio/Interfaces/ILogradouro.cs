using System;

namespace MORM.Dominio.Interfaces
{
    public interface ILogradouro
    {
        int Id_Logradouro { get; set; }
        string U_Version { get; set; }
        int Cd_Operador { get; set; }
        DateTime Dt_Cadastro { get; set; }
        int Id_Municipio { get; set; }
        int Id_Bairro { get; set; }
        string Cd_Cep { get; set; }
        string Ds_TipoLogradouro { get; set; }
        string Ds_Logradouro { get; set; }
        string Nr_Logradouro { get; set; }
        string Ds_Complemento { get; set; }

        IMunicipio Municipio { get; set; }
        IBairro Bairro { get; set; }
    }
}
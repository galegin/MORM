using MORM.Dominio.Atributos;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Entidades
{
    [Tabela("LOGRADOURO")]
    public class Logradouro : ILogradouro
    {
        [Campo("ID_LOGRADOURO", CampoTipo.Key)]
        public int Id_Logradouro { get; set; }
        [Campo("U_VERSION", CampoTipo.Nul)]
        public string U_Version { get; set; }
        [Campo("CD_OPERADOR", CampoTipo.Req)]
        public int Cd_Operador { get; set; }
        [Campo("DT_CADASTRO", CampoTipo.Req)]
        public DateTime Dt_Cadastro { get; set; }
        [Campo("ID_MUNICIPIO", CampoTipo.Req)]
        public int Id_Municipio { get; set; }
        [Campo("ID_BAIRRO", CampoTipo.Req)]
        public int Id_Bairro { get; set; }
        [Campo("CD_CEP", CampoTipo.Req)]
        public string Cd_Cep { get; set; }
        [Campo("DS_TIPOLOGRADOURO", CampoTipo.Req)]
        public string Ds_TipoLogradouro { get; set; }
        [Campo("DS_LOGRADOURO", CampoTipo.Req)]
        public string Ds_Logradouro { get; set; }
        [Campo("NR_LOGRADOURO", CampoTipo.Req)]
        public string Nr_Logradouro { get; set; }
        [Campo("DS_COMPLEMENTO", CampoTipo.Req)]
        public string Ds_Complemento { get; set; }

        [Relacao(nameof(Id_Municipio))]
        public IMunicipio Municipio { get; set; }
        [Relacao(nameof(Id_Bairro))]
        public IBairro Bairro { get; set; }

        public Logradouro()
        {
            Municipio = new Municipio();
            Bairro = new Bairro();
        }
    }
}
using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Logradouro")]
    public class LogradouroModel : AbstractModel
    {
        #region variaveis
        private int _id_Logradouro;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Municipio;
        private int _id_Bairro;
        private string _cd_Cep;
        private string _ds_TipoLogradouro;
        private string _ds_Logradouro;
        private string _nr_Logradouro;
        private string _ds_Complemento;
        #endregion
        
        #region propriedades
        public int Id_Logradouro
        {
            get => _id_Logradouro;
            set => SetField(ref _id_Logradouro, value);
        }
        public string U_Version
        {
            get => _u_Version;
            set => SetField(ref _u_Version, value);
        }
        public int Cd_Operador
        {
            get => _cd_Operador;
            set => SetField(ref _cd_Operador, value);
        }
        public DateTime Dt_Cadastro
        {
            get => _dt_Cadastro;
            set => SetField(ref _dt_Cadastro, value);
        }
        public int Id_Municipio
        {
            get => _id_Municipio;
            set => SetField(ref _id_Municipio, value);
        }
        public int Id_Bairro
        {
            get => _id_Bairro;
            set => SetField(ref _id_Bairro, value);
        }
        public string Cd_Cep
        {
            get => _cd_Cep;
            set => SetField(ref _cd_Cep, value);
        }
        public string Ds_TipoLogradouro
        {
            get => _ds_TipoLogradouro;
            set => SetField(ref _ds_TipoLogradouro, value);
        }
        public string Ds_Logradouro
        {
            get => _ds_Logradouro;
            set => SetField(ref _ds_Logradouro, value);
        }
        public string Nr_Logradouro
        {
            get => _nr_Logradouro;
            set => SetField(ref _nr_Logradouro, value);
        }
        public string Ds_Complemento
        {
            get => _ds_Complemento;
            set => SetField(ref _ds_Complemento, value);
        }
        #endregion
    }
}
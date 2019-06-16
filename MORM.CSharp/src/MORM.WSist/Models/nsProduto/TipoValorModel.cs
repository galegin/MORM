using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("TipoValor")]
    public class TipoValorModel : AbstractModel
    {
        #region variaveis
        private int _id_TipoValor;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_TipoValor;
        private string _ds_TipoValor;
        #endregion
        
        #region propriedades
        public int Id_TipoValor
        {
            get => _id_TipoValor;
            set => SetField(ref _id_TipoValor, value);
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
        public string Cd_TipoValor
        {
            get => _cd_TipoValor;
            set => SetField(ref _cd_TipoValor, value);
        }
        public string Ds_TipoValor
        {
            get => _ds_TipoValor;
            set => SetField(ref _ds_TipoValor, value);
        }
        #endregion
    }
}
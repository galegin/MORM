using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("TipoVariacao")]
    public class TipoVariacaoModel : AbstractModel
    {
        #region variaveis
        private int _id_TipoVariacao;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_TipoVariacao;
        private string _ds_TipoVariacao;
        #endregion
        
        #region propriedades
        public int Id_TipoVariacao
        {
            get => _id_TipoVariacao;
            set => SetField(ref _id_TipoVariacao, value);
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
        public string Cd_TipoVariacao
        {
            get => _cd_TipoVariacao;
            set => SetField(ref _cd_TipoVariacao, value);
        }
        public string Ds_TipoVariacao
        {
            get => _ds_TipoVariacao;
            set => SetField(ref _ds_TipoVariacao, value);
        }
        #endregion
    }
}
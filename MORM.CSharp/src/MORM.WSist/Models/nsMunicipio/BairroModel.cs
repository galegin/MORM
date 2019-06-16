using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Bairro")]
    public class BairroModel : AbstractModel
    {
        #region variaveis
        private int _id_Bairro;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _ds_Bairro;
        #endregion
        
        #region propriedades
        public int Id_Bairro
        {
            get => _id_Bairro;
            set => SetField(ref _id_Bairro, value);
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
        public string Ds_Bairro
        {
            get => _ds_Bairro;
            set => SetField(ref _ds_Bairro, value);
        }
        #endregion
    }
}
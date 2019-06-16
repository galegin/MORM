using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("Estado")]
    public class EstadoModel : AbstractModel
    {
        #region variaveis
        private int _id_Estado;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private int _id_Pais;
        private string _cd_Estado;
        private string _nm_Estado;
        private string _ds_Sigla;
        #endregion
        
        #region propriedades
        public int Id_Estado
        {
            get => _id_Estado;
            set => SetField(ref _id_Estado, value);
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
        public int Id_Pais
        {
            get => _id_Pais;
            set => SetField(ref _id_Pais, value);
        }
        public string Cd_Estado
        {
            get => _cd_Estado;
            set => SetField(ref _cd_Estado, value);
        }
        public string Nm_Estado
        {
            get => _nm_Estado;
            set => SetField(ref _nm_Estado, value);
        }
        public string Ds_Sigla
        {
            get => _ds_Sigla;
            set => SetField(ref _ds_Sigla, value);
        }
        #endregion
    }
}
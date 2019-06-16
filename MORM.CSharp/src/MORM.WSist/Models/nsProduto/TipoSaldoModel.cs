using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("TipoSaldo")]
    public class TipoSaldoModel : AbstractModel
    {
        #region variaveis
        private int _id_TipoSaldo;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_TipoSaldo;
        private string _ds_TipoSaldo;
        #endregion
        
        #region propriedades
        public int Id_TipoSaldo
        {
            get => _id_TipoSaldo;
            set => SetField(ref _id_TipoSaldo, value);
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
        public string Cd_TipoSaldo
        {
            get => _cd_TipoSaldo;
            set => SetField(ref _cd_TipoSaldo, value);
        }
        public string Ds_TipoSaldo
        {
            get => _ds_TipoSaldo;
            set => SetField(ref _ds_TipoSaldo, value);
        }
        #endregion
    }
}
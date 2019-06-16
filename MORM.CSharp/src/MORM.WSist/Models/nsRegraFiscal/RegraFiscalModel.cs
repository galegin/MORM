using MORM.Apresentacao.Models;
using MORM.Dominio.Atributos;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("RegraFiscal")]
    public class RegraFiscalModel : AbstractModel
    {
        #region variaveis
        private int _id_RegraFiscal;
        private string _u_Version;
        private int _cd_Operador;
        private DateTime _dt_Cadastro;
        private string _cd_RegraFiscal;
        private string _ds_RegraFiscal;
        private int _cd_CfopEntrada;
        private int _cd_CfopSaida;
        #endregion
        
        #region propriedades
        public int Id_RegraFiscal
        {
            get => _id_RegraFiscal;
            set => SetField(ref _id_RegraFiscal, value);
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
        public string Cd_RegraFiscal
        {
            get => _cd_RegraFiscal;
            set => SetField(ref _cd_RegraFiscal, value);
        }
        public string Ds_RegraFiscal
        {
            get => _ds_RegraFiscal;
            set => SetField(ref _ds_RegraFiscal, value);
        }
        public int Cd_CfopEntrada
        {
            get => _cd_CfopEntrada;
            set => SetField(ref _cd_CfopEntrada, value);
        }
        public int Cd_CfopSaida
        {
            get => _cd_CfopSaida;
            set => SetField(ref _cd_CfopSaida, value);
        }
        #endregion
    }
}
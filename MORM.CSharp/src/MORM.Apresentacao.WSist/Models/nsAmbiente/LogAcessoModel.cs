using MORM.Infra.CrossCutting;
using System;

namespace MORM.Apresentacao.Models
{
    [SVC("LogAcesso")]
    public class LogAcessoModel : AbstractModel
    {
        #region variaveis
        private DateTime _dataLog;
        private int _sequenciaLog;
        private int _codigoEmpresa;
        private int _codigoUsuario;
        private string _codigoServico;
        private string _codigoMetodo;
        private int _qtdeAcesso;
        #endregion
        
        #region propriedades
        public DateTime DataLog
        {
            get => _dataLog;
            set => SetField(ref _dataLog, value);
        }
        public int SequenciaLog
        {
            get => _sequenciaLog;
            set => SetField(ref _sequenciaLog, value);
        }
        public int CodigoEmpresa
        {
            get => _codigoEmpresa;
            set => SetField(ref _codigoEmpresa, value);
        }
        public int CodigoUsuario
        {
            get => _codigoUsuario;
            set => SetField(ref _codigoUsuario, value);
        }
        public string CodigoServico
        {
            get => _codigoServico;
            set => SetField(ref _codigoServico, value);
        }
        public string CodigoMetodo
        {
            get => _codigoMetodo;
            set => SetField(ref _codigoMetodo, value);
        }
        public int QtdeAcesso
        {
            get => _qtdeAcesso;
            set => SetField(ref _qtdeAcesso, value);
        }
        #endregion
    }
}
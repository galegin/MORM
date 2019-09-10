using MORM.CrossCutting;

namespace MORM.Apresentacao.Models
{
    [SVC("Permissao")]
    public class PermissaoModel : AbstractModel
    {
        #region variaveis
        private int _codigoEmpresa;
        private int _codigoUsuario;
        private string _codigoServico;
        private string _codigoMetodo;
        #endregion
        
        #region propriedades
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
        #endregion
    }
}
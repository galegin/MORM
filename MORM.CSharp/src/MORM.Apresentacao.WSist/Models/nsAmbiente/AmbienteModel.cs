using MORM.CrossCutting;

namespace MORM.Apresentacao.WSist
{
    [SVC("Ambiente")]
    public class AmbienteModel : AbstractModel
    {
        #region variaveis
        private string _codigo;
        private string _database;
        private string _username;
        private string _password;
        private int _codigoEmpresa;
        private int _codigoUsuario;
        #endregion
        
        #region propriedades
        public string Codigo
        {
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        public string Database
        {
            get => _database;
            set => SetField(ref _database, value);
        }
        public string Username
        {
            get => _username;
            set => SetField(ref _username, value);
        }
        public string Password
        {
            get => _password;
            set => SetField(ref _password, value);
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
        #endregion
    }
}
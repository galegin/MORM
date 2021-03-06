using MORM.CrossCutting;

namespace MORM.Apresentacao.WSist
{
    [SVC("MigracaoEnt")]
    public class MigracaoEntModel : AbstractModel
    {
        #region variaveis
        private string _codigo;
        private string _versao;
        #endregion
        
        #region propriedades
        public string Codigo
        {
            get => _codigo;
            set => SetField(ref _codigo, value);
        }
        public string Versao
        {
            get => _versao;
            set => SetField(ref _versao, value);
        }
        #endregion
    }
}
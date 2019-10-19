using MaterialDesignThemes.Wpf;

namespace MORM.Apresentacao.WSist
{
    public class AbstractPackIconViewModel : AbstractViewModel
    {
        #region variaveis
        private PackIconKind _packIconKindOpcao;
        #endregion

        #region propriedades
        public PackIconKind PackIconKindOpcao
        {
            get => _packIconKindOpcao;
            set => SetField(ref _packIconKindOpcao, value);
        }
        public int Codigo => (int)PackIconKindOpcao;
        public string Desricao => PackIconKindOpcao.ToString();
        #endregion

        #region construtores
        public AbstractPackIconViewModel(PackIconKind packIconKindOpcao)
        {
            PackIconKindOpcao = packIconKindOpcao;
        }
        #endregion
    }
}
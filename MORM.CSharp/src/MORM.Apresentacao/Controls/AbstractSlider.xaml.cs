using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Controls.ViewsModel;

namespace MORM.Apresentacao.Controls
{
    public partial class AbstractSlider : AbstractUserControl
    {
        #region propriedades
        public AbstractTimer Timer { get; }
        #endregion

        #region construtores
        public AbstractSlider()
        {
            InitializeComponent();
            DataContext = new AbstractSliderViewModel();
            Timer = new AbstractTimer(OnTimerExecute, tempo: AbstractTimer.TEMPO_SECOND * 5);
        }
        #endregion

        #region metodos
        private void OnTimerExecute(object sender)
        {
            if (AbstractAppAction.IsActiveApp)
            {
                this.Dispatcher.Invoke(() => 
                {
                    var vm = DataContext as AbstractSliderViewModel;
                    vm.SetarProxima();
                });
            }
        }
        #endregion
    }
}

using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractClienteViewModel : AbstractViewModel
    {
        #region constantes
        #endregion

        #region variaveis
        private AbstractClienteModel _model;
        #endregion

        #region propriedades
        public AbstractClienteModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region commandos
        #endregion

        #region construtores
        public AbstractClienteViewModel()
        {
            Model = new AbstractClienteModel();
        }
        #endregion

        #region metodos
        #endregion
    }
}
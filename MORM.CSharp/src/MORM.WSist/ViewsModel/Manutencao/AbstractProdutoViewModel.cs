using MORM.Apresentacao.ViewsModel;
using MORM.WSist.Models.Manutencao;

namespace MORM.WSist.ViewsModel.Manutencao
{
    public class AbstractProdutoViewModel : AbstractViewModel
    {
        #region constantes
        #endregion

        #region variaveis
        private AbstractProdutoModel _model;
        #endregion

        #region propriedades
        public AbstractProdutoModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region commandos
        #endregion

        #region construtores
        public AbstractProdutoViewModel()
        {
            Model = new AbstractProdutoModel();
        }
        #endregion

        #region metodos
        #endregion
    }
}
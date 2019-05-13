using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelRelat<TModel> : AbstractViewModel<TModel>, IAbstractViewModelRelat
    {
        #region comandos
        public override AbstractCommand Limpar { get; } = new LimparTela<TModel>();
        public override AbstractCommand Consultar { get; } = new ConsultarTela<TModel>();
        #endregion

        #region construtores
        public AbstractViewModelRelat() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
        }
        #endregion
    }
}
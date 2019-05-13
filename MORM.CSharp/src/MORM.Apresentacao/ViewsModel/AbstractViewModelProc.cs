using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelProc<TModel> : AbstractViewModel<TModel>, IAbstractViewModelProc
    {
        #region comandos
        public override AbstractCommand Limpar { get; } = new LimparTela<TModel>();
        public override AbstractCommand Consultar { get; } = new ConsultarTela<TModel>();
        #endregion

        #region construtores
        public AbstractViewModelProc() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
        }
        #endregion
    }
}
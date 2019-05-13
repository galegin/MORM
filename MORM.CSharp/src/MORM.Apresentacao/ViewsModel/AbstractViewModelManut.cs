using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelManut<TModel> : AbstractViewModel<TModel>, IAbstractViewModelManut
    {
        #region comandos
        public override AbstractCommand Limpar { get; } = new LimparTela<TModel>();
        public override AbstractCommand Consultar { get; } = new ConsultarTela<TModel>();
        public override AbstractCommand Incluir { get; } = new IncluirTela<TModel>();
        public override AbstractCommand Alterar { get; } = new AlterarTela<TModel>();
        public override AbstractCommand Salvar { get; } = new SalvarTela<TModel>();
        public override AbstractCommand Excluir { get; } = new ExcluirTela<TModel>();
        #endregion

        #region construtores
        public AbstractViewModelManut() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
            IsExibirIncluir = true;
            IsExibirAlterar = true;
            IsExibirSalvar = true;
            IsExibirExcluir = true;
        }
        #endregion
    }
}
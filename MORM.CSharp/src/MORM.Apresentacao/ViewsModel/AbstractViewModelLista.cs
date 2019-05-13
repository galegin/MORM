using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModelLista<TModel> : AbstractViewModel<TModel>, IAbstractViewModelLista
    {
        #region comandos
        public override AbstractCommand Limpar { get; } = new LimparTela<TModel>();
        public override AbstractCommand Consultar { get; } = new ConsultarTela<TModel>();
        public override AbstractCommand Exportar { get; } = new ExportarTela<TModel>();
        public override AbstractCommand Importar { get; } = new ImportarTela<TModel>();
        public override AbstractCommand Imprimir { get; } = new ImprimirTela<TModel>();
        #endregion

        #region construtores
        public AbstractViewModelLista() : base()
        {
            IsExibirLimpar = true;
            IsExibirConsultar = true;
            IsExibirExportar = true;
            IsExibirImportar = true;
            IsExibirImprimir = true;
        }
        #endregion
    }
}
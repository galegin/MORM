using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.ViewsModel;
using System.Collections.Generic;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractOpcaoViewModel<TModel> : AbstractViewModel
    {
        #region variaveis
        private bool _isExibirFechar = false;
        private bool _isExibirVoltar = true;
        private bool _isExibirLimpar = true;
        private bool _isExibirConsultar = true;
        private bool _isExibirIncluir = false;
        private bool _isExibirAlterar = false;
        private bool _isExibirSalvar = true;
        private bool _isExibirExcluir = true;
        private bool _isExibirExportar = false;
        private bool _isExibirImportar = false;
        private bool _isExibirImprimir = false;
        private TModel _model;
        #endregion

        #region propriedades
        public bool IsExibirFechar
        {
            get => _isExibirFechar;
            set => SetField(ref _isExibirFechar, value);
        }
        public bool IsExibirVoltar
        {
            get => _isExibirVoltar;
            set => SetField(ref _isExibirVoltar, value);
        }
        public bool IsExibirLimpar
        {
            get => _isExibirLimpar;
            set => SetField(ref _isExibirLimpar, value);
        }
        public bool IsExibirConsultar
        {
            get => _isExibirConsultar;
            set => SetField(ref _isExibirConsultar, value);
        }
        public bool IsExibirIncluir
        {
            get => _isExibirIncluir;
            set => SetField(ref _isExibirIncluir, value);
        }
        public bool IsExibirAlterar
        {
            get => _isExibirAlterar;
            set => SetField(ref _isExibirAlterar, value);
        }
        public bool IsExibirSalvar
        {
            get => _isExibirSalvar;
            set => SetField(ref _isExibirSalvar, value);
        }
        public bool IsExibirExcluir
        {
            get => _isExibirExcluir;
            set => SetField(ref _isExibirExcluir, value);
        }
        public bool IsExibirExportar
        {
            get => _isExibirExportar;
            set => SetField(ref _isExibirExportar, value);
        }
        public bool IsExibirImportar
        {
            get => _isExibirImportar;
            set => SetField(ref _isExibirImportar, value);
        }
        public bool IsExibirImprimir
        {
            get => _isExibirImprimir;
            set => SetField(ref _isExibirImprimir, value);
        }
        public TModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region comandos
        public FecharTela Fechar { get; set; } = new FecharTela();
        public VoltarTelaAnterior Voltar { get; set; } = new VoltarTelaAnterior();
        public LimparTela<TModel> Limpar { get; set; } = new LimparTela<TModel>();
        public ConsultarTela<TModel> Consultar { get; set; } = new ConsultarTela<TModel>();
        public IncluirTela<TModel> Incluir { get; set; } = new IncluirTela<TModel>();
        public AlterarTela<TModel> Alterar { get; set; } = new AlterarTela<TModel>();
        public SalvarTela<TModel> Salvar { get; set; } = new SalvarTela<TModel>();
        public ExcluirTela<TModel> Excluir { get; set; } = new ExcluirTela<TModel>();
        public ExportarTela<TModel> Exportar { get; set; } = new ExportarTela<TModel>();
        public ImportarTela<TModel> Importar { get; set; } = new ImportarTela<TModel>();
        public ImprimirTela<TModel> Imprimir { get; set; } = new ImprimirTela<TModel>();
        #endregion

        #region contrutores
        public AbstractOpcaoViewModel(TModel model)
        {
            Model = model;
        }
        #endregion
    }

    public class AbstractOpcaoViewModel<TFiltro, TModel> : AbstractOpcaoViewModel<TModel>
    {
        #region variaveis
        private TFiltro _filtro;
        private List<TModel> _lista;
        #endregion

        #region propriedades
        public TFiltro Filtro
        {
            get => _filtro;
            set => SetField(ref _filtro, value);
        }
        public List<TModel> Lista
        {
            get => _lista;
            set => SetField(ref _lista, value);
        }
        #endregion

        #region comandos
        public ListarTela<TFiltro, TModel> Listar { get; set; } = new ListarTela<TFiltro, TModel>();
        #endregion

        #region contrutores
        public AbstractOpcaoViewModel(TFiltro filtro, TModel model) : base(model)
        {
            Lista = new List<TModel>();
        }
        #endregion
    }
}
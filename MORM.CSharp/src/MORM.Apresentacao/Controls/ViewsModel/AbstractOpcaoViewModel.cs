using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractOpcaoViewModel : AbstractViewModel
    {
        #region constantes
        #endregion

        #region variaveis
        private bool _isExibirFechar = false;
        private bool _isExibirVoltar = true;
        private bool _isExibirLimpar = true;
        private bool _isExibirConsultar = true;
        private bool _isExibirSalvar = true;
        private bool _isExibirExcluir = true;
        private bool _isExibirExportar = false;
        private bool _isExibirImportar = false;
        private bool _isExibirImprimir = false;
        private object _model;
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
        public object Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region comandos
        public FecharTela Fechar { get; set; } = new FecharTela();
        public VoltarTelaAnterior Voltar { get; set; } = new VoltarTelaAnterior();
        public LimparTela Limpar { get; set; } = new LimparTela();
        public ConsultarTela Consultar { get; set; } = new ConsultarTela();
        public SalvarTela Salvar { get; set; } = new SalvarTela();
        public ExcluirTela Excluir { get; set; } = new ExcluirTela();
        public ExportarTela Exportar { get; set; } = new ExportarTela();
        public ImportarTela Importar { get; set; } = new ImportarTela();
        public ImprimirTela Imprimir { get; set; } = new ImprimirTela();
        #endregion

        #region contrutores
        public AbstractOpcaoViewModel(object model)
        {
            Model = model;
        }
        #endregion

        #region metodos
        #endregion
    }
}
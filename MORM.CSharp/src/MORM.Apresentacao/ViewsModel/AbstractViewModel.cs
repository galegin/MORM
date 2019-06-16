using MORM.Apresentacao.Colors;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.Comps;
using System;
using System.Collections.Generic;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModel : BaseNotifyPropertyChanged, IAbstractViewModel
    {
        #region variaveis
        #region confirmacao
        private bool _isConfirmado;
        #endregion
        #region exibir
        private bool _isExibirFechar = false;
        private bool _isExibirVoltar = true;
        private bool _isExibirLimpar = true;
        private bool _isExibirConsultar = true;
        private bool _isExibirExportar = false;
        private bool _isExibirImportar = false;
        private bool _isExibirImprimir = false;
        private bool _isExibirIncluir = false;
        private bool _isExibirAlterar = false;
        private bool _isExibirSalvar = true;
        private bool _isExibirExcluir = true;
        #endregion
        #region esquema
        private EsquemaCor _esquemaCabecalho;
        private EsquemaCor _esquemaCorpo;
        private EsquemaCor _esquemaDestaque;
        private EsquemaCor _esquemaDetalhe;
        private EsquemaCor _esquemaMenu;
        private EsquemaCor _esquemaRodape;
        private EsquemaCor _esquemaTitulo;
        #endregion
        #endregion

        #region propriedades
        #region action
        public Action CloseAction { get; set; }
        #endregion
        #region confirmacao
        public bool IsConfirmado
        {
            get => _isConfirmado;
            set => SetField(ref _isConfirmado, value);
        }
        #endregion
        #region exibir
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
        #endregion
        #region esquema
        public EsquemaCor EsquemaCabecalho
        {
            get => _esquemaCabecalho;
            set => SetField(ref _esquemaCabecalho, value);
        }
        public EsquemaCor EsquemaCorpo
        {
            get => _esquemaCorpo;
            set => SetField(ref _esquemaCorpo, value);
        }
        public EsquemaCor EsquemaDestaque
        {
            get => _esquemaDestaque;
            set => SetField(ref _esquemaDestaque, value);
        }
        public EsquemaCor EsquemaDetalhe
        {
            get => _esquemaDetalhe;
            set => SetField(ref _esquemaDetalhe, value);
        }
        public EsquemaCor EsquemaMenu
        {
            get => _esquemaMenu;
            set => SetField(ref _esquemaMenu, value);
        }
        public EsquemaCor EsquemaRodape
        {
            get => _esquemaRodape;
            set => SetField(ref _esquemaRodape, value);
        }
        public EsquemaCor EsquemaTitulo
        {
            get => _esquemaTitulo;
            set => SetField(ref _esquemaTitulo, value);
        }
        #endregion
        #endregion

        #region comandos
        public virtual AbstractCommand Fechar { get; } = new FecharTela();
        public virtual AbstractCommand Voltar { get; } = new VoltarTelaAnterior();
        public virtual AbstractCommand Limpar { get; }
        public virtual AbstractCommand Consultar { get; }
        public virtual AbstractCommand Exportar { get; }
        public virtual AbstractCommand Importar { get; }
        public virtual AbstractCommand Imprimir { get; }
        public virtual AbstractCommand Incluir { get; }
        public virtual AbstractCommand Alterar { get; }
        public virtual AbstractCommand Salvar { get; }
        public virtual AbstractCommand Excluir { get; }
        #endregion

        #region construtores
        public AbstractViewModel()
        {
            EsquemaCabecalho = EsquemaTipo.Cabecalho.GetEsquema();
            EsquemaCorpo = EsquemaTipo.Corpo.GetEsquema();
            EsquemaDestaque = EsquemaTipo.Destaque.GetEsquema();
            EsquemaDetalhe = EsquemaTipo.Detalhe.GetEsquema();
            EsquemaMenu = EsquemaTipo.Menu.GetEsquema();
            EsquemaRodape = EsquemaTipo.Rodape.GetEsquema();
            EsquemaTitulo = EsquemaTipo.Titulo.GetEsquema();
        }
        #endregion

        #region metodos
        public virtual object GetModel() => null;
        public virtual string GetNomeModel() => null;
        public virtual string GetTituloModel() => null;
        #endregion
    }

    public class AbstractViewModel<TModel> : AbstractViewModel, IAbstractViewModel<TModel>
    {
        #region variaveis
        private TModel _model;
        #endregion

        #region propriedades
        public TModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region comandos
        public override AbstractCommand Limpar { get; }
        public override AbstractCommand Consultar { get; }
        public override AbstractCommand Exportar { get; }
        public override AbstractCommand Importar { get; }
        public override AbstractCommand Imprimir { get; }
        public override AbstractCommand Incluir { get; } 
        public override AbstractCommand Alterar { get; } 
        public override AbstractCommand Salvar { get; }
        public override AbstractCommand Excluir { get; } 
        #endregion

        #region construtores
        public AbstractViewModel() : base()
        {
            Model = Activator.CreateInstance<TModel>();
            IsExibirFechar = true;

            var mainCommand = TelaUtils.Instance.MainCommand;
            Limpar = mainCommand.GetCommand<TModel>(CommandTipo.Limpar);
            Exportar = mainCommand.GetCommand<TModel>(CommandTipo.Exportar);
            Importar = mainCommand.GetCommand<TModel>(CommandTipo.Importar);
            Imprimir = mainCommand.GetCommand<TModel>(CommandTipo.Imprimir);
            Consultar = mainCommand.GetCommand<TModel>(CommandTipo.Consultar);
            Incluir = mainCommand.GetCommand<TModel>(CommandTipo.Incluir);
            Alterar = mainCommand.GetCommand<TModel>(CommandTipo.Alterar);
            Salvar = mainCommand.GetCommand<TModel>(CommandTipo.Salvar);
            Excluir = mainCommand.GetCommand<TModel>(CommandTipo.Excluir);
        }
        #endregion

        #region metodos
        public override object GetModel() => Model;
        public override string GetNomeModel() => nameof(Model);
        public override string GetTituloModel()
        {
            return
                typeof(TModel).Name
                    .Replace("Abstract", "")
                    .Replace("Model", "")
                    .Replace("View", "");
        }
        #endregion
    }

    public class AbstractViewModel<TFiltro, TModel> : AbstractViewModel<TModel>, IAbstractViewModel<TFiltro, TModel>
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

        #region construtores
        public AbstractViewModel() : base()
        {
            Filtro = Activator.CreateInstance<TFiltro>();
            Lista = new List<TModel>();
        }
        #endregion
    }
}
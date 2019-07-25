using MORM.Apresentacao.Colors;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.Comps;
using MORM.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private bool _isExibirVoltar = false;
        private bool _isExibirLimpar = false;
        private bool _isExibirListar = false;
        private bool _isExibirConsultar = false;
        private bool _isExibirExportar = false;
        private bool _isExibirImportar = false;
        private bool _isExibirImprimir = false;
        private bool _isExibirIncluir = false;
        private bool _isExibirAlterar = false;
        private bool _isExibirSalvar = false;
        private bool _isExibirExcluir = false;
        private bool _isExibirRetornar = false;
        private bool _isExibirSelecionar = false;
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
        public Action SelecionarListaAction { get; set; }
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
        public bool IsExibirListar
        {
            get => _isExibirListar;
            set => SetField(ref _isExibirListar, value);
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
        public bool IsExibirRetornar
        {
            get => _isExibirRetornar;
            set => SetField(ref _isExibirRetornar, value);
        }
        public bool IsExibirSelecionar
        {
            get => _isExibirSelecionar;
            set => SetField(ref _isExibirSelecionar, value);
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
        public virtual AbstractCommand Listar { get; }
        public virtual AbstractCommand Consultar { get; }
        public virtual AbstractCommand Exportar { get; }
        public virtual AbstractCommand Importar { get; }
        public virtual AbstractCommand Imprimir { get; }
        public virtual AbstractCommand Incluir { get; }
        public virtual AbstractCommand Alterar { get; }
        public virtual AbstractCommand Salvar { get; }
        public virtual AbstractCommand Excluir { get; }
        public virtual AbstractCommand Retornar { get; }
        public virtual AbstractCommand Selecionar { get; }
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
        public virtual object GetFiltro() => null;
        public virtual void SetFiltro(object filtro) { }

        public virtual object GetLista() => null;
        public virtual void SetLista(object lista) { }

        public virtual object GetModel() => null;
        public virtual void SetModel(object model) { }

        public virtual string GetNomeFiltro() => null;
        public virtual string GetNomeLista() => null;
        public virtual string GetNomeModel() => null;

        public virtual string GetTituloModel() => null;

        public void SetOpcoes(string[] opcoes)
        {
            var properties = GetType().GetProperties().Where(x => x.Name.StartsWith("IsExibir"));
            foreach (var prop in properties)
            {
                prop.SetValue(this, opcoes.ToList().Any(x => prop.Name.EndsWith(x)));
            }
        }

        public void ClearAll()
        {
            ClearFiltro();
            ClearLista();
            ClearModel();
        }
        public virtual void ClearFiltro() { }
        public virtual void ClearLista() { }
        public virtual void ClearModel() { }

        public virtual void RetornarModel() { }

        public virtual void SelecionarLista() => SelecionarListaAction?.Invoke();
        #endregion
    }

    public class AbstractViewModel<TModel> : AbstractViewModel, IAbstractViewModel<TModel>
        where TModel : class
    {
        #region variaveis
        private TModel _filtro;
        private List<TModel> _lista;
        private TModel _model;
        #endregion

        #region propriedades
        public TModel Filtro
        {
            get => _filtro;
            set => SetField(ref _filtro, value);
        }
        public List<TModel> Lista
        {
            get => _lista;
            set => SetField(ref _lista, value);
        }
        public TModel Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        #endregion

        #region comandos
        public override AbstractCommand Limpar { get; }
        public override AbstractCommand Listar { get; }
        public override AbstractCommand Consultar { get; }
        public override AbstractCommand Exportar { get; }
        public override AbstractCommand Importar { get; }
        public override AbstractCommand Imprimir { get; }
        public override AbstractCommand Incluir { get; } 
        public override AbstractCommand Alterar { get; } 
        public override AbstractCommand Salvar { get; }
        public override AbstractCommand Excluir { get; }
        public override AbstractCommand Retornar { get; }
        public override AbstractCommand Selecionar { get; }
        #endregion

        #region construtores
        public AbstractViewModel() : base()
        {
            Filtro = Activator.CreateInstance<TModel>();
            Lista = new List<TModel>();
            Model = Activator.CreateInstance<TModel>();

            SetOpcoes(new[] { nameof(IsExibirFechar) });

            var mainCommand = TelaUtils.Instance.MainCommand;
            Limpar = mainCommand.GetCommand<TModel>(CommandTipo.Limpar);
            Exportar = mainCommand.GetCommand<TModel>(CommandTipo.Exportar);
            Importar = mainCommand.GetCommand<TModel>(CommandTipo.Importar);
            Imprimir = mainCommand.GetCommand<TModel>(CommandTipo.Imprimir);
            Listar = mainCommand.GetCommand<TModel>(CommandTipo.Listar);
            Consultar = mainCommand.GetCommand<TModel>(CommandTipo.Consultar);
            Incluir = mainCommand.GetCommand<TModel>(CommandTipo.Incluir);
            Alterar = mainCommand.GetCommand<TModel>(CommandTipo.Alterar);
            Salvar = mainCommand.GetCommand<TModel>(CommandTipo.Salvar);
            Excluir = mainCommand.GetCommand<TModel>(CommandTipo.Excluir);
            Retornar = mainCommand.GetCommand<TModel>(CommandTipo.Retornar);
            Selecionar = mainCommand.GetCommand<TModel>(CommandTipo.Selecionar);
        }
        #endregion

        #region metodos
        public override object GetFiltro() => Filtro;
        public override void SetFiltro(object filtro)
        {
            Filtro.CloneInstancePropOrFieldAll(filtro);
        }

        public override object GetLista() => Lista;
        public override void SetLista(object lista)
        {
            if (lista is List<TModel>)
                Lista = lista as List<TModel>;
        }

        public override object GetModel() => Model;
        public override void SetModel(object model)
        {
            Model.CloneInstancePropOrFieldAll(model);
        }            

        public override string GetNomeFiltro() => nameof(Filtro);
        public override string GetNomeLista() => nameof(Lista);
        public override string GetNomeModel() => nameof(Model);

        public override string GetTituloModel()
        {
            return
                typeof(TModel).Name
                    .Replace("Abstract", "")
                    .Replace("Model", "")
                    .Replace("View", "");
        }

        public override void ClearFiltro() => 
            Filtro.ClearInstancePropOrFieldAll();
        public override void ClearLista() => 
            Lista = new List<TModel>();
        public override void ClearModel() => 
            Model.ClearInstancePropOrFieldAll();

        public override void RetornarModel()
        {
            IsConfirmado = true;
            Fechar.ExecuteCommand(this);
        }
        #endregion
    }
}
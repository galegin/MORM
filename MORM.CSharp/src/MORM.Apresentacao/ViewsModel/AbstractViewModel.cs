using MORM.Apresentacao.Colors;
using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Commands.Tela;
using MORM.Apresentacao.Comps;
using MORM.Apresentacao.Views;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MORM.Apresentacao.ViewsModel
{
    public class AbstractViewModel : BaseNotifyPropertyChanged, IAbstractViewModel
    {
        #region variaveis
        #region objeto
        protected object _filtro;
        protected object _model;
        protected IList _lista;
        #endregion
        #region confirmacao
        private bool _isConfirmado;
        #endregion
        #region exibir
        private bool _isExibirFechar = false;
        private bool _isExibirVoltar = false;
        private bool _isExibirConfirmar = false;
        private bool _isExibirCancelar = false;
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
        #region objeto
        public virtual Type ElementType => Model.GetType();
        public virtual object Filtro
        {
            get => _filtro;
            set => SetField(ref _filtro, value);
        }
        public virtual object Model
        {
            get => _model;
            set => SetField(ref _model, value);
        }
        public virtual IList Lista
        {
            get => _lista;
            set => SetField(ref _lista, value);
        }
        #endregion
        #region action
        public Action CloseAction { get; set; }
        public Action SelecionarAction { get; set; }
        public Action ConfirmarAction { get; set; }
        public Action CancelarAction { get; set; }
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
        public bool IsExibirConfirmar
        {
            get => _isExibirConfirmar;
            set => SetField(ref _isExibirConfirmar, value);
        }
        public bool IsExibirCancelar
        {
            get => _isExibirCancelar;
            set => SetField(ref _isExibirCancelar, value);
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
        public AbstractCommand Fechar { get; set; } = new FecharTela();
        public AbstractCommand Voltar { get; set; } = new VoltarTelaAnterior();
        public AbstractCommand Limpar { get; set; }
        public AbstractCommand Listar { get; set; }
        public AbstractCommand Consultar { get; set; }
        public AbstractCommand Exportar { get; set; }
        public AbstractCommand Importar { get; set; }
        public AbstractCommand Imprimir { get; set; }
        public AbstractCommand Incluir { get; set; }
        public AbstractCommand Alterar { get; set; }
        public AbstractCommand Salvar { get; set; }
        public AbstractCommand Excluir { get; set; }
        public AbstractCommand Retornar { get; set; }
        public AbstractCommand Selecionar { get; set; }
        public AbstractCommand Confirmar { get; set; }
        public AbstractCommand Cancelar { get; set; }
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
        public virtual string GetTitulo() => null;
        public virtual void ClearAll() { }

        public void SetOpcoes(string[] opcoes)
        {
            GetType()
                .GetProperties()
                .Where(x => x.Name.StartsWith("IsExibir"))
                .ToList()
                .ForEach(prop => prop.SetValue(this, opcoes.ToList().Any(x => prop.Name.EndsWith(x))));
        }

        public virtual void RetornarModel()
        {
            IsConfirmado = true;
            Fechar.ExecuteCommand(this);
        }

        public virtual void ConsultarChave() { }
        public virtual void BuscarDescricao() { }

        public virtual void SelecionarLista() => SelecionarAction?.Invoke();

        public virtual void ConfirmarTela() { }
        public virtual void CancelarTela() { }
        #endregion
    }

    public class AbstractViewModel<TModel> : AbstractViewModel, IAbstractViewModel<TModel>
        where TModel : class
    {
        #region variaveis
        //private TModel _filtro;
        //private List<TModel> _lista;
        //private TModel _model;
        #endregion

        #region propriedades
        public override Type ElementType => typeof(TModel);
        public TModel oFiltro
        {
            get => _filtro as TModel;
            set => SetField(ref _filtro, value);
        }
        public List<TModel> oLista
        {
            get => _lista as List<TModel>;
            set => SetField(ref _lista, value);
        }
        public TModel oModel
        {
            get => _model as TModel;
            set => SetField(ref _model, value);
        }
        #endregion

        #region construtores
        public AbstractViewModel() : base()
        {
            Filtro = Activator.CreateInstance<TModel>();
            Lista = new List<TModel>();
            Model = Activator.CreateInstance<TModel>();
            
            SetOpcoes(new[] { nameof(IsExibirFechar) });

            #region commands
            var mainCommand = TelaUtils.Instance.MainCommand;
            Limpar = mainCommand.GetCommand<TModel>(CommandTipo.Limpar);
            Listar = mainCommand.GetCommand<TModel>(CommandTipo.Listar);
            Consultar = mainCommand.GetCommand<TModel>(CommandTipo.Consultar);
            Exportar = mainCommand.GetCommand<TModel>(CommandTipo.Exportar);
            Importar = mainCommand.GetCommand<TModel>(CommandTipo.Importar);
            Imprimir = mainCommand.GetCommand<TModel>(CommandTipo.Imprimir);
            Incluir = mainCommand.GetCommand<TModel>(CommandTipo.Incluir);
            Alterar = mainCommand.GetCommand<TModel>(CommandTipo.Alterar);
            Salvar = mainCommand.GetCommand<TModel>(CommandTipo.Salvar);
            Excluir = mainCommand.GetCommand<TModel>(CommandTipo.Excluir);
            Retornar = mainCommand.GetCommand<TModel>(CommandTipo.Retornar);
            Selecionar = mainCommand.GetCommand<TModel>(CommandTipo.Selecionar);
            Confirmar = mainCommand.GetCommand<TModel>(CommandTipo.Confirmar);
            Cancelar = mainCommand.GetCommand<TModel>(CommandTipo.Cancelar);
            #endregion
        }
        #endregion

        #region metodos
        public override string GetTitulo()
        {
            return
                typeof(TModel).Name
                    .Replace("Abstract", "")
                    .Replace("Model", "")
                    .Replace("View", "");
        }
        public override void ClearAll()
        {
            Filtro.ClearInstancePropOrFieldAll();
            Lista = null;
            Model?.ClearInstancePropOrFieldAll();
        }
        public override void ConsultarChave()
        {
            if (this.IsModelChavePreenchida())
            {
                Consultar.ExecuteCommand(this);
            }
        }
        public void SetarAtualizacao()
        {
            oModel?.SetInstancePropOrField("Cd_Operador", 1); // ?????
            oModel?.SetInstancePropOrField("Dt_Cadastro", DateTime.Now);
        }
        #endregion
    }
}
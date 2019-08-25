using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractCampoViewModel : AbstractViewModel
    {
        #region variaveis
        private AbstractSource _source;
        private AbstractCampoTipo _tipo;
        private MetadataCampo _campo;
        private AbstractSelecao _selecao;
        private AbstractCampoFiltro _filtros;
        #endregion

        #region propriedades
        public AbstractSource Source
        {
            get => _source;
            set => SetField(ref _source, value);
        }

        public AbstractCampoTipo Tipo
        {
            get => _tipo;
            set => SetField(ref _tipo, value);
        }

        public MetadataCampo Campo
        {
            get => _campo;
            set
            {
                SetField(ref _campo, value);
                SetarFiltros();
                SetarSelecao();
            }
        }

        public override object Selecao
        {
            get => _selecao;
            set => SetField(ref _selecao, value as AbstractSelecao);
        }

        public AbstractCampoFiltro Filtros
        {
            get => _filtros;
            set => SetField(ref _filtros, value);
        }
        #endregion

        #region construtores
        public AbstractCampoViewModel()
        {
        }

        public AbstractCampoViewModel(AbstractSource source, AbstractCampoTipo tipo, MetadataCampo campo) 
            : this()
        {
            Source = source;
            Tipo = tipo;
            Campo = campo;
        }
        #endregion

        #region metodos
        private void SetarFiltros()
        {
            if (_campo != null)
            {
                if (Tipo.IsInter() || Tipo.IsSelecao() || _campo.IsClasse())
                {
                    Filtros = _campo.Prop.PropertyType.GetCampoFiltro();
                    Filtros.Tipo = Tipo;
                }
            }
        }

        private void SetarSelecao()
        {
            if (Tipo.IsSelecao() || Campo.Classe != null || Campo.Valores != null)
                _selecao = new AbstractSelecao(Tipo.IsSelecao(), Campo.Classe, Campo.Valores);
        }

        public override void BuscarDescricao()
        {
            if (Campo.Classe == null)
                return;

            var campoProp = Campo.Prop.Name;
            var campoCod = Campo.Classe.GetCampoCod();
            var campoDes = Campo.Classe.GetCampoDes();

            if (string.IsNullOrWhiteSpace(campoCod) || string.IsNullOrWhiteSpace(campoDes))
                return;
            if (!campoProp.Equals(campoCod))
                return;

            var valorCod = Source.Model.GetInstancePropOrField(campoProp);
            if (valorCod?.IsValueNull() ?? true)
                return;

            var objeto = Activator.CreateInstance(Campo.Classe);
            objeto.SetInstancePropOrField(campoCod, valorCod);

            var connector = Campo.Classe.GetConsultarConnector();
            var retorno = ObjetoExecute.Execute(connector, "Executar", objeto);
            var valorDes = retorno.GetInstancePropOrField(campoDes);

            Filtros.SetInstancePropOrField("ValorDes", valorDes);
        }

        public override void SelecionarLista()
        {
            var classe = Campo.IsClasse() ? Campo.Classe :
                Campo.IsValores() ? typeof(ValorTipagem) : null;
            if (classe == null)
                return;

            var typeFor = TypeForConvert
                .GetTypeFor(typeof(AbstractViewModel<>), classe);

            var objeto = AbstractViewListaExtensions.Execute(typeFor, null, 
                selecao: _selecao);

            if (objeto != null)
            {
                if (Tipo.IsSelecao())
                    SetarRetornoLista(objeto as IList);
                else
                    SetarRetornoValor(objeto);
            }
        }

        private void SetarRetornoLista(IList lista)
        {
            Filtros.SetInstancePropOrField("ValorSel", lista);
        }

        private void SetarRetornoValor(object objeto)
        {
            var valor = objeto.GetInstancePropOrField(Campo.Prop.Name);
            Source.Model.SetInstancePropOrField(Campo.Prop.Name, valor);
        }
        #endregion
    }
}
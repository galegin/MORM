using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.Commands;
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
                if (_campo != null)
                {
                    if (Tipo.IsInter() || Tipo.IsSelecao() || _campo.IsClasse())
                    {
                        Filtros = _campo.Prop.PropertyType.GetCampoFiltro();
                        Filtros.Tipo = Tipo;
                    }
                }
            }
        }

        public string Descricao
        {
            get => Campo.Descricao;
            set => Campo.Descricao = value;
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
            Selecionar = new SelecionarCampo();
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
            if (Campo.Classe != null)
                SelecionarLista(Campo.Classe, null);
            else if (Campo.Valores != null)
                SelecionarLista(typeof(ValorTipagem), Campo.Valores);
        }

        private void SelecionarLista(Type classe, IList valores)
        {
            var typeFor = TypeForConvert
                .GetTypeFor(typeof(AbstractViewModel<>), Campo.Classe);

            var selecao = GetSelecao(valores);

            var objeto = AbstractViewListaExtensions.Execute(typeFor, null, 
                selecao: selecao);
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
            Filtros.SetInstancePropOrField("ValorSel", lista); // ?????
        }

        private void SetarRetornoValor(object objeto)
        {
            var valor = objeto.GetInstancePropOrField(Campo.Prop.Name);
            Source.Model.SetInstancePropOrField(Campo.Prop.Name, valor);
        }

        private AbstractSelecao GetSelecao(IList valores)
        {
            if (Tipo.IsSelecao() || Campo.Classe != null || Campo.Valores != null)
                return new AbstractSelecao(Tipo.IsSelecao(), Campo.Classe, Campo.Valores);
            return null;
        }
        #endregion
    }
}
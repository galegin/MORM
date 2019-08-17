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

        public string Formato
        {
            get => Campo.Formato;
            set => Campo.Formato = value;
        }

        public MetadataCampo Campo
        {
            get => _campo;
            set
            {
                SetField(ref _campo, value);
                if (_campo != null)
                {
                    if (Tipo.IsInter() || Tipo.IsSelecao())
                        Filtro = _campo.Prop.PropertyType.GetCampoFiltro();
                }
            }
        }

        public string Descricao
        {
            get => Campo.Descricao;
            set => Campo.Descricao = value;
        }

        public int Tamanho
        {
            get => Campo.Tamanho;
            set => Campo.Tamanho = value;
        }

        public int Precisao
        {
            get => Campo.Precisao;
            set => Campo.Precisao = value;
        }

        public IList Valores
        {
            get => Campo.Valores;
            set => Campo.Valores = value;
        }

        public Type Classe
        {
            get => Campo.Classe;
            set => Campo.Classe = value;
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
            var campoPropDes = $"{Campo.Prop.Name}Des";
            var campoCod = Campo.Classe.GetCampoCod();
            var campoDes = Campo.Classe.GetCampoDes();

            if (string.IsNullOrWhiteSpace(campoCod) || string.IsNullOrWhiteSpace(campoDes))
                return;
            if (!campoProp.Equals(campoCod))
                return;

            var valorCod = Source.Model.GetInstancePropOrField(campoProp);

            var objeto = Activator.CreateInstance(Campo.Classe);
            objeto.SetInstancePropOrField(campoCod, valorCod);

            var connector = Campo.Classe.GetConsultarConnector();
            var retorno = ObjetoExecute.Execute(connector, "Execute", objeto);
            var valorDes = retorno.GetInstancePropOrField(campoDes);

            Source.Model.SetInstancePropOrField(campoPropDes, valorDes);
        }

        public override void SelecionarLista()
        {
            if (Classe != null)
                SelecionarLista(Classe, null);
            else if (Valores != null)
                SelecionarLista(typeof(ValorTipagem), Valores);
        }

        private void SelecionarLista(Type classe, IList valores)
        {
            var typeFor = TypeForConvert
                .GetTypeFor(typeof(AbstractViewModel<>), Classe);

            var objeto = AbstractViewListaExtensions.Execute(typeFor, null, valores: Valores);
            if (objeto != null)
            {
                var valor = objeto.GetInstancePropOrField(Campo.Prop.Name);
                Source.Model.SetInstancePropOrField(Campo.Prop.Name, valor);
            }
        }
        #endregion
    }
}
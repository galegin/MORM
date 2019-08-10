using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Controls.Commands;
using MORM.Apresentacao.Views;
using MORM.Apresentacao.ViewsModel;
using MORM.Dominio.Extensions;
using MORM.Infra.CrossCutting;
using System;
using System.Collections;

namespace MORM.Apresentacao.Controls.ViewsModel
{
    public class AbstractCampoViewModel : AbstractViewModel
    {
        #region variaveis
        private object _source;
        private string _nomeBinding;
        private AbstractCampoTipo _tipo;
        private AbstractCampoFormato _formato;
        private MetadataCampo _campo;
        private AbstractCampoDef _campoBtn = new AbstractCampoDef { Tamanho = 150 };
        private AbstractCampoDef _campoDes = new AbstractCampoDef { Tamanho = 100 };
        private AbstractCampoDef _campoIni = new AbstractCampoDef { Tamanho = 100 };
        private AbstractCampoDef _campoFin = new AbstractCampoDef { Tamanho = 100 };
        private AbstractCampoDef _campoSel = new AbstractCampoDef { Tamanho = 300 };
        private AbstractCampoDef _campoTip = new AbstractCampoDef { Tamanho = 300 };
        #endregion

        #region propriedades
        public object Source { get => _source; set => SetField(ref _source, value); }
        public string NomeBinding { get => _nomeBinding; set => SetField(ref _nomeBinding, value); }

        public AbstractCampoTipo Tipo
        {
            get => _tipo;
            set
            {
                SetField(ref _tipo, value);
                CampoBtn.IsExibir = value.IsIndiv() || value.IsInter();
                CampoIni.IsExibir = value.IsIndiv() || value.IsInter();
                CampoFin.IsExibir = value.IsInter();
                CampoDes.IsExibir = value.IsDescr();
                CampoSel.IsExibir = value.IsSelecao();
                CampoTip.IsExibir = value.IsTipagem();
            }
        }

        public AbstractCampoFormato Formato
        {
            get => _formato;
            set => SetField(ref _formato, value);
        }

        public MetadataCampo Campo
        {
            get => _campo;
            set
            {
                SetField(ref _campo, value);
                if (_campo != null)
                {
                    Descricao = _campo.Descricao;
                    Tamanho = _campo.Tamanho;
                    Precisao = _campo.Precisao;
                    Formato = _campo.Prop.GetCampoFormato();
                    Valores = _campo.Valores;
                    Classe = Valores == null ? _campo.Classe : null;
                }
            }
        }

        public string Descricao
        {
            get => CampoBtn.Descricao;
            set => CampoBtn.Descricao = value;
        }

        public int Tamanho
        {
            get => CampoIni.Tamanho / 10;
            set
            {
                CampoIni.Tamanho = value * 10;
                CampoFin.Tamanho = value * 10;
                CampoDes.Tamanho = value * 10 * 2;
            }
        }

        public int Precisao
        {
            get => CampoIni.Precisao;
            set
            {
                CampoIni.Precisao = value;
                CampoFin.Precisao = value;
            }
        }

        public IList Valores
        {
            get => CampoBtn.Valores;
            set
            {
                CampoBtn.Valores = value;
                CampoIni.Valores = value;
                CampoFin.Valores = value;
                CampoDes.Valores = value;
            }
        }

        public Type Classe
        {
            get => CampoBtn.Classe;
            set
            {
                CampoBtn.Classe = value;
                CampoIni.Classe = value;
                CampoFin.Classe = value;
                CampoDes.Classe = value;
            }
        }

        public AbstractCampoDef CampoBtn { get => _campoBtn; set => SetField(ref _campoBtn, value); }
        public AbstractCampoDef CampoIni { get => _campoIni; set => SetField(ref _campoIni, value); }
        public AbstractCampoDef CampoFin { get => _campoFin; set => SetField(ref _campoFin, value); }
        public AbstractCampoDef CampoDes { get => _campoDes; set => SetField(ref _campoDes, value); }
        public AbstractCampoDef CampoSel { get => _campoSel; set => SetField(ref _campoSel, value); }
        public AbstractCampoDef CampoTip { get => _campoTip; set => SetField(ref _campoTip, value); }
        #endregion

        #region construtores
        public AbstractCampoViewModel()
        {
            Selecionar = new SelecionarCampo();
        }

        public AbstractCampoViewModel(object source, string nomeBinding, AbstractCampoTipo tipo, MetadataCampo campo) 
            : this()
        {
            Source = source;
            NomeBinding = nomeBinding;
            Tipo = tipo;
            Campo = campo;
        }
        #endregion

        #region metodos
        public override void BuscarDescricao()
        {
            var model = Source.GetInstancePropOrField(NomeBinding);

            var valorCod = model.GetInstancePropOrField(CampoIni.Codigo);

            var objeto = Activator.CreateInstance(CampoIni.Classe);
            objeto.SetInstancePropOrField(CampoIni.Codigo, valorCod);

            var connector = CampoIni.Classe.GetConsultarConnector();
            var retorno = ObjetoExecute.Execute(connector, "Execute", objeto);
            var valorDes = retorno.GetInstancePropOrField(CampoDes.Codigo);

            model.SetInstancePropOrField(CampoDes.Codigo, valorDes);
        }

        public override void GerarIntervalo()
        {
            var model = Source.GetInstancePropOrField(NomeBinding);

            var campoFiltro = CampoIni.Tipo.GetCampoFiltro();
            campoFiltro.SetInstancePropOrField("ValorIni", model.GetInstancePropOrField(CampoIni.Codigo));
            campoFiltro.SetInstancePropOrField("ValorFin", model.GetInstancePropOrField(CampoFin.Codigo));
            campoFiltro.SetInstancePropOrField("ValorSel", model.GetInstancePropOrField(CampoSel.Codigo));

            model.SetInstancePropOrField("ValorDes", campoFiltro.GetInstancePropOrField("ValorDes"));
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
                var model = (Source as IAbstractViewModel).GetInstancePropOrField(NomeBinding);
                model.SetInstancePropOrField(Campo.Prop.Name, valor);
            }
        }
        #endregion
    }
}
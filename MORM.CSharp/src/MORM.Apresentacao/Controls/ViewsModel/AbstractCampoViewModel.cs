using MORM.Apresentacao.Controls.Commands;
using MORM.Apresentacao.Extensions;
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
        private AbstractCampoTipo _tipo;
        private AbstractEditTipo _editTipo;
        private MetadataCampo _campo;
        private CampoDef _campoBtn = new CampoDef { Tamanho = 150 };
        private CampoDef _campoDes = new CampoDef { Tamanho = 100 };
        private CampoDef _campoIni = new CampoDef { Tamanho = 100 };
        private CampoDef _campoFin = new CampoDef { Tamanho = 100 };
        private CampoDef _campoSel = new CampoDef { Tamanho = 300 };
        private CampoDef _campoTip = new CampoDef { Tamanho = 300 };
        #endregion

        #region propriedades
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

        public AbstractEditTipo EditTipo
        {
            get => _editTipo;
            set => SetField(ref _editTipo, value);
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
                    EditTipo = _campo.Prop.GetEditTipo();
                    Valores = _campo.Prop.GetValoresCampo();
                    Classe = Valores == null ? _campo.Prop.GetClasseCampo() : null;
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

        public CampoDef CampoBtn { get => _campoBtn; set => SetField(ref _campoBtn, value); }
        public CampoDef CampoIni { get => _campoIni; set => SetField(ref _campoIni, value); }
        public CampoDef CampoFin { get => _campoFin; set => SetField(ref _campoFin, value); }
        public CampoDef CampoDes { get => _campoDes; set => SetField(ref _campoDes, value); }
        public CampoDef CampoSel { get => _campoSel; set => SetField(ref _campoSel, value); }
        public CampoDef CampoTip { get => _campoTip; set => SetField(ref _campoTip, value); }
        #endregion

        #region construtores
        public AbstractCampoViewModel()
        {
            Selecionar = new SelecionarCampo();
        }

        public AbstractCampoViewModel(AbstractCampoTipo tipo, MetadataCampo campo) 
            : this()
        {
            Tipo = tipo;
            Campo = campo;
        }
        #endregion

        #region metodos
        public override void ConsultarChave()
        {
        }

        public override void BuscarDescricao()
        {
        }

        public override void GerarIntervalo()
        {
        }

        public override void SelecionarLista()
        {
            if (Classe != null)
                SelecionarClasse();
            else if (Valores != null)
                SelecionarValores();
        }

        private void SelecionarClasse()
        {
            var typeFor = TypeForConvert
                .GetTypeFor(typeof(AbstractViewModel<>), Classe);

            var objeto = AbstractViewListaExtensions.Execute(typeFor, null);
            if (objeto != null)
                CampoIni.Valor = objeto;
        }

        private void SelecionarValores()
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Apresentacao.Controls
{
    public class SelecaoItemModel : AbstractModel
    {
        #region variaveis
        private object _model;
        private string _codigoCampo;
        private string _codigoValor;
        private string _descricaoCampo;
        private string _descricaoValor;
        private bool _isSelecionado;
        #endregion

        #region propriedades
        public string Codigo
        {
            get => _codigoValor;
            set => SetField(ref _codigoValor, value);
        }
        public string Descricao
        {
            get => _descricaoValor;
            set => SetField(ref _descricaoValor, value);
        }
        public bool IsSelecionado
        {
            get => _isSelecionado;
            set => SetField(ref _isSelecionado, value);
        }
        #endregion

        #region construtores
        public SelecaoItemModel(object model, bool? isSelecionado = null)
        {
            SetModel(model);
            _isSelecionado = isSelecionado ?? false;
        }
        #endregion

        #region metodos
        private void SetModel(object model)
        {
            _model = model;
            _codigoCampo = model.GetCampoCod();
            _codigoValor = model.GetInstancePropOrField(_codigoCampo) as string;
            _descricaoCampo = model.GetCampoCod();
            _descricaoValor = model.GetInstancePropOrField(_codigoCampo) as string;
        }
        public void Selecionar(bool isSelecionado)
        {
            IsSelecionado = isSelecionado;
        }
        public void InverterSelecao()
        {
            IsSelecionado = !IsSelecionado;
        }
        #endregion
    }

    public static class SelecaoItemModelExtensions
    {
        public static IList GetListaSelecaoItem(this IList lista)
        {
            var retorno = new List<SelecaoItemModel>();
            foreach (var item in lista)
                retorno.Add(new SelecaoItemModel(item));
            return retorno;
        }

        public static Metadata GetMetadata()
        {
            return typeof(SelecaoItemModel).GetMetadata();
        }
    }
}
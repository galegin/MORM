using MORM.Apresentacao.Models;
using MORM.CrossCutting;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Apresentacao.Controls
{
    public class SelecaoItemModel : AbstractModel
    {
        #region variaveis
        private object _model;
        private string _codigoCampo;
        private object _codigoValor;
        private string _descricaoCampo;
        private string _descricaoValor;
        private bool _isSelecionado;
        #endregion

        #region propriedades
        public object Codigo
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
        public SelecaoItemModel()
        {
        }
        #endregion

        #region metodos
        private void SetModel(object model)
        {
            _model = model;
            _codigoCampo = model.GetCampoCod();
            _codigoValor = model.GetInstancePropOrField(_codigoCampo).ToString();
            _descricaoCampo = model.GetCampoDes();
            _descricaoValor = model.GetInstancePropOrField(_descricaoCampo).ToString();
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

        public static IList GetListaSelecaoItemCodigo(this IList lista)
        {
            var retorno = new List<object>();
            foreach (var item in lista)
            {
                var selecaoItem = item as SelecaoItemModel;
                if (selecaoItem?.IsSelecionado ?? false)
                    retorno.Add(selecaoItem.Codigo);
            }
            return retorno;
        }

        public static void SetInverterSelecao(this IList lista)
        {
            foreach (var item in lista)
                (item as SelecaoItemModel)?.InverterSelecao();
        }

        public static void SetSelecionarTodos(this IList lista)
        {
            foreach (var item in lista)
                (item as SelecaoItemModel)?.Selecionar(true);
        }

        public static Metadata GetMetadata()
        {
            return typeof(SelecaoItemModel).GetMetadata();
        }
    }
}
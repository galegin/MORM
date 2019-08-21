using MORM.Apresentacao.Models;
using System.Collections;
using System.Collections.Generic;

namespace MORM.Apresentacao.Controls
{
    public class SelecaoItemModel : AbstractModel
    {
        #region variaveis
        private object _model;
        private bool _isSelecionado;
        #endregion

        #region propriedades
        public object Model
        {
            get => _model;
            set => SetField(ref _model, value);
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
            _model = model;
            _isSelecionado = isSelecionado ?? false;
        }
        #endregion

        #region metodos
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
    }
}
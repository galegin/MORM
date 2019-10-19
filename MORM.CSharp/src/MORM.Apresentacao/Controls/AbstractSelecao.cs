using MORM.CrossCutting;
using System;
using System.Collections;
using System.Linq;

namespace MORM.Apresentacao
{
    public class AbstractSelecao : AbstractModel
    {
        #region variaveis
        private Type _classe;
        private IList _valores;
        private bool _isSelecao;
        #endregion

        #region propriedades
        public Type Classe
        {
            get => _classe;
            set => SetField(ref _classe, value);
        }
        public IList Valores
        {
            get => _valores;
            set => SetField(ref _valores, value);
        }
        public bool IsSelecao
        {
            get => _isSelecao;
            set => SetField(ref _isSelecao, value);
        }
        #endregion

        #region construtores
        public AbstractSelecao(bool isSelecao = false, 
            Type classe = null, IList valores = null)
        {
            _isSelecao = isSelecao;
            _classe = classe;
            _valores = (isSelecao && valores != null) ? 
                _valores = valores.GetListaSelecaoItem() : valores;
        }

        public Metadata GetMetadata(IAbstractViewModel vm)
        {
            vm.Selecao = this;

            if (IsSelecao)
                return SelecaoItemModelExtensions.GetMetadata();
            else if (Valores != null)
                return ValoresExtensions.GetMetadata();
            else if (Classe != null)
                return Classe.GetMetadata();

            return null;
        }
        #endregion
    }

    public static class AbstractSelecaoExtensions
    {
        private static string[] _lstCampoSel =
        {
            nameof(SelecaoItemModel.IsSelecionado)
        };

        public static bool IsEditavel(this AbstractSelecao selecao, string campo)
        {
            if (selecao?.IsSelecao ?? false)
                return _lstCampoSel.Contains(campo);
            return false;
        }
    }
}
using MaterialDesignThemes.Wpf;
using MORM.Apresentacao.ViewsModel;
using System;
using System.Collections.Generic;

namespace MORM.WSist.ViewsModel.Lista
{
    public class AbstractPackIconViewModelLista : AbstractViewModel
    {
        #region variaveis
        private List<PackIconKind> _listaPackIcon;
        private const int _qtdeRegistro = 50;
        private int _numeroPagina = 0;
        private int _registroTotal => _listaPackIcon.Count;
        private int _registroInicial => _numeroPagina * _qtdeRegistro;
        private int _registroFinal => _numeroPagina == _totalPagina ? _registroTotal : (_numeroPagina + 1) * _qtdeRegistro;
        private int _totalPagina => _registroTotal / _qtdeRegistro;
        #endregion

        #region propriedades
        public int NumeroPagina
        {
            get => _numeroPagina;
            set => SetField(ref _numeroPagina, value);
        }
        public List<PackIconKind> Lista
        {
            get
            {
                var listaPackIcon = new List<PackIconKind>();

                for (int i = _registroInicial; i < _registroFinal; i++)
                    listaPackIcon.Add(_listaPackIcon[i]);

                return listaPackIcon;
            }
            set { }
        }
        #endregion

        #region construtores
        public AbstractPackIconViewModelLista()
        {
            _listaPackIcon = GetLista();
        }
        #endregion

        #region metodos
        private List<PackIconKind> GetLista()
        {
            var listaPackIcon = new List<PackIconKind>();

            foreach (var packIconKindStr in Enum.GetValues(typeof(PackIconKind)))
            {
                var packIconKind = (PackIconKind)packIconKindStr;
                if (!listaPackIcon.Contains(packIconKind))
                    listaPackIcon.Add(packIconKind);
            }

            return listaPackIcon;
        }
        #endregion
    }
}
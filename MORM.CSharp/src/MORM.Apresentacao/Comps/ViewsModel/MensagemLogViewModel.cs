﻿using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Comps.ViewsModel
{
    public class MensagemLogViewModel : AbstractViewModel
    {
        #region variaveis
        private string _mensagem;
        #endregion

        #region propriedades
        public string Mensagem
        {
            get => _mensagem;
            set => SetField(ref _mensagem, value);
        }
        #endregion
    }
}
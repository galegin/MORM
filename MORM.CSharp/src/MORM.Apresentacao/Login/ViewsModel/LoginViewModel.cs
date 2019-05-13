﻿using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Login.Commands;
using MORM.Apresentacao.Login.Models;
using MORM.Apresentacao.ViewsModel;

namespace MORM.Apresentacao.Login.ViewsModel
{
    public class LoginViewModel : AbstractViewModel<LoginModel>
    {
        #region variaveis
        private string _token;
        #endregion

        #region propriedades
        public string Token
        {
            get => _token;
            set => SetField(ref _token, value);
        }
        #endregion

        #region comandos
        public FecharLogin FecharLogin { get; set; }
        public LogarSistema LogarSistema { get; set; }
        #endregion

        #region construtores
        public LoginViewModel()
        {
            FecharLogin = new FecharLogin();
            LogarSistema = new LogarSistema();
        }
        #endregion

        #region metodos
        public void SetarLogin(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return;
            Token = token;
            FecharLogin.ExecuteCommand(this);
        }
        #endregion
    }
}
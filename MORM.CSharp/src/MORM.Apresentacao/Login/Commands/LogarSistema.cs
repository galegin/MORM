﻿using MORM.Apresentacao.Commands;
using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.Login.ViewsModel;
using MORM.Apresentacao.Models;
using MORM.Infra.CrossCutting;

namespace MORM.Apresentacao.Login.Commands
{
    public class LogarSistema : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as LoginViewModel;

            if (string.IsNullOrWhiteSpace(vm?.Model?.Login) || string.IsNullOrWhiteSpace(vm?.Model?.Senha))
                return;

            var dto = new ValidarAmbienteInModel
            {
                Login = vm.Model.Login,
                Senha = vm.Model.Senha,
            };
            var connector = new AbstractAmbienteConnector();
            var token = connector.Executar(dto).Token;

            vm.SetarLogin(token);
            AbstractApiConsumer.SetTokenInterno(token);
        }
    }
}
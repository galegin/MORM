﻿using MORM.Apresentacao.Connectors;
using MORM.Apresentacao.ViewsModel;
using System.ComponentModel;

namespace MORM.Apresentacao.Commands.Tela
{
    [Description("Incluir")]
    public class IncluirCommand : AbstractCommand
    {
        public override void Execute(object parameter)
        {
            var vm = parameter as IAbstractViewModel;
            var connector = vm.ElementType.GetIncluirConnector();
            connector.Incluir(vm.Model);
        }
    }
}
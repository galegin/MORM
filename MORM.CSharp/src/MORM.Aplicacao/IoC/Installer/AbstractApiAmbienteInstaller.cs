﻿using MORM.Ioc.Installer;
using MORM.Utilidade.Entidades;
using MORM.Utilidade.Interfaces;

namespace MORM.Aplicacao.Ioc.Installer
{
    public class AbstractApiAmbienteInstaller : AbstractAmbienteInstaller
    {
        protected override void Setup()
        {
            Register<IAmbiente, Ambiente>();
            Register<IUsuario, Usuario>();
            Register<IEmpresa, Empresa>();
            Register<ITerminal, Terminal>();
        }
    }
}
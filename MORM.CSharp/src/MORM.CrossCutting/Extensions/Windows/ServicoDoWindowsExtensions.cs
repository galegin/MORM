using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MORM.CrossCutting
{
    public enum ServicoDoWindowsTipo
    {
        Instalar,
        Desinstalar,
        Iniciar,
        Parar
    }

    public static class ServicoDoWindowsExtensions
    {
        private class Commando
        {
            public string Cmd { get; set; }
            public string Arg { get; set; } = string.Empty;
        }

        public static void SetService(this ServicoDoWindowsTipo tipo, string serviceName, string serviceExec)
        {
            List<Commando> listaDeComando = null;

            switch (tipo)
            {
                case ServicoDoWindowsTipo.Instalar:
                    var pathExe = AppDomain.CurrentDomain.BaseDirectory;

                    listaDeComando = new List<Commando>()
                    {
                        new Commando() { Cmd = $"sc", Arg = $"create \"{serviceName}\" displayname= \"{serviceName}\" binPath= \"{Path.Combine(pathExe, serviceExec)}\" start= auto" },
                        new Commando() { Cmd = $"sc", Arg = $"config \"{serviceName}\" start= auto" },
                        new Commando() { Cmd = $"sc", Arg = $"start \"{serviceName}\"" }
                    };

                    break;

                case ServicoDoWindowsTipo.Desinstalar:
                    listaDeComando = new List<Commando>()
                    {
                        new Commando() { Cmd = $"sc", Arg = $"stop \"{serviceName}\"" },
                        new Commando() { Cmd = $"sc", Arg = $"delete \"{serviceName}\"" },
                    };

                    break;

                case ServicoDoWindowsTipo.Iniciar:
                    listaDeComando = new List<Commando>()
                    {
                        new Commando() { Cmd = $"sc", Arg = $"start \"{serviceName}\"" }
                    };

                    break;

                case ServicoDoWindowsTipo.Parar:
                    listaDeComando = new List<Commando>()
                    {
                        new Commando() { Cmd = $"sc", Arg = $"stop \"{serviceName}\"" },
                    };

                    break;
            }

            Process process = new Process();

            if (Environment.OSVersion.Version.Major >= 6)
            {
                process.StartInfo.Verb = "runas";
            }

            foreach (var comando in listaDeComando)
            {
                // Configure the process using the StartInfo properties.
                process.StartInfo.FileName = comando.Cmd;
                process.StartInfo.Arguments = comando.Arg;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
                process.Start();
                process.WaitForExit();// Waits here for the process to exit.
            }
        }
    }
}
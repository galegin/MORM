using MORM.Dominio.Extensoes;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Extensions
{
    public static class TerminalExtensions
    {
        /// <summary>
        /// 
        /// setar terminal com base na chamada por linha de comando
        /// 
        ///  terminal
        ///   -ti - id
        ///   -tc - codigo
        ///   -td - descricao
        ///   
        /// </summary>
        /// <param name="terminal"></param>
        public static void SetTerminal(this ITerminal terminal)
        {
            var argAnt = string.Empty;

            terminal.Cd_Terminal = "0";
            terminal.Ds_Terminal = "Terminal teste";

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                switch (argAnt)
                {
                    case "-ti":
                        terminal.Id_Terminal = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-tc":
                        terminal.Cd_Terminal = arg;
                        break;
                    case "-td":
                        terminal.Ds_Terminal = arg;
                        break;
                }

                argAnt = arg;
            }
        }
    }
}
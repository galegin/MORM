using MORM.Utilidade.Extensoes;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Utilidade.Extensions
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
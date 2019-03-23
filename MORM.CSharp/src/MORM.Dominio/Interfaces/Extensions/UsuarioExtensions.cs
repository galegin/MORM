using MORM.Dominio.Extensoes;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Extensions
{
    public static class UsuarioExtensions
    {
        /// <summary>
        /// 
        /// setar usuario com base na chamada por linha de comando
        /// 
        ///  usuario
        ///   -ui - id
        ///   -ul - login
        ///   -un - nome
        ///   
        /// </summary>
        /// <param name="usuario"></param>
        public static void SetUsuario(this IUsuario usuario)
        {
            var argAnt = string.Empty;

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                switch (argAnt)
                {
                    case "-ui":
                        usuario.Id_Usuario = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-ul":
                        usuario.Nm_Login = arg;
                        break;
                    case "-un":
                        usuario.Nm_Usuario = arg;
                        break;
                }

                argAnt = arg;
            }
        }
    }
}
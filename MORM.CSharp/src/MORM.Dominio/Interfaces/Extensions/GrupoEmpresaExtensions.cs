using MORM.Dominio.Extensoes;
using MORM.Dominio.Interfaces;
using System;

namespace MORM.Dominio.Extensions
{
    public static class GrupoEmpresaExtensions
    {
        /// <summary>
        /// 
        /// setar grupo empresa com base na chamada por linha de comando
        /// 
        ///  grupo empresa
        ///   -gi - id
        ///   -gc - codigo
        ///   -gn - nome
        ///   
        /// </summary>
        /// <param name="grupoEmpresa"></param>
        public static void SetGrupoEmpresa(this IGrupoEmpresa grupoEmpresa)
        {
            var argAnt = string.Empty;

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                switch (argAnt)
                {
                    case "-gi":
                        grupoEmpresa.Id_GrupoEmpresa = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-gc":
                        grupoEmpresa.Cd_GrupoEmpresa = arg;
                        break;
                    case "-gn":
                        grupoEmpresa.Nm_GrupoEmpresa = arg;
                        break;
                }

                argAnt = arg;
            }
        }
    }
}
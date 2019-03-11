using MORM.Utilidade.Extensoes;
using MORM.Utilidade.Interfaces;
using System;

namespace MORM.Utilidade.Extensions
{
    public static class EmpresaExtensions
    {
        /// <summary>
        /// 
        /// setar empresa com base na chamada por linha de comando
        /// 
        ///  empresa
        ///   -ei - id
        ///   -ec - codigo
        ///   -en - descricao
        ///   
        /// </summary>
        /// <param name="empresa"></param>
        public static void SetEmpresa(this IEmpresa empresa)
        {
            var argAnt = string.Empty;

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                switch (argAnt)
                {
                    case "-ei":
                        empresa.Id_Empresa = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-ec":
                        empresa.Cd_Empresa = arg;
                        break;
                    case "-ed":
                        empresa.Ds_Empresa = arg;
                        break;
                }

                argAnt = arg;
            }
        }
    }
}
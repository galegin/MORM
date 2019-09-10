using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using MORM.CrossCutting;
using System;

namespace MORM.Dominio.Extensions
{
    public static class AmbienteExtensions
    {
        /// <summary>
        /// 
        /// setar ambiente com base na chamada por linha de comando
        /// 
        ///  ambiente
        ///   -ac - codigo
        ///     - teste
        ///   
        ///   -at - tipo database
        ///    - Oracle
        ///    - MySql
        ///    - PostgreSql
        ///    - SqLite
        ///    
        ///   -ad - database
        ///    - {appPath}\Dados  
        /// 
        ///   -au - username
        ///    - uteste
        ///    
        ///   -ap - password
        ///    - uteste
        ///    
        ///   -ah - hostname
        ///    - localhost
        ///    
        ///   -av - provider
        ///   
        ///   -ec - codigo empresa
        ///   -uc - cdigo usuario
        ///   -tc - codigo terminal
        ///   
        /// </summary>
        /// <param name="ambiente"></param>
        public static void SetAmbiente(this IAmbiente ambiente)
        {
            var argAnt = string.Empty;

            ambiente.Codigo = "teste";

            foreach (var arg in Environment.GetCommandLineArgs())
            {
                switch (argAnt)
                {
                    case "-ac":
                        ambiente.Codigo = arg;
                        break;
                    case "-at":
                        ambiente.TipoDatabase = (TipoDatabase)Enum.Parse(typeof(TipoDatabase), arg);
                        break;
                    case "-ad":
                        ambiente.Database = arg;
                        break;
                    case "-au":
                        ambiente.Username = arg;
                        break;
                    case "-ap":
                        ambiente.Password = arg;
                        break;
                    case "-ah":
                        ambiente.Hostname = arg;
                        break;
                    case "-av":
                        ambiente.ProviderName = arg;
                        break;
                    case "-ec":
                        ambiente.CodigoEmpresa = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-tc":
                        ambiente.CodigoTerminal = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                    case "-uc":
                        ambiente.CodigoUsuario = Convert.ToInt32(arg.ObterNumero() ?? 0);
                        break;
                }

                argAnt = arg;
            }
        }
    }
}
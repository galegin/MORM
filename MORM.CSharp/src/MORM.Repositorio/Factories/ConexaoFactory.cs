using MORM.Repositorio.Context;
using MORM.Repositorio.Interfaces;
using MORM.Dominio.Interfaces;
using System.Collections.Generic;

namespace MORM.Repositorio.Factories
{
    public enum TipoConexao
    {
        Ambiente,
        Create,
        Instance,
        Global,
        Login,
    }

    public class ConexaoFactory
    {
        private static Dictionary<string, IConexao> _listaDeConexao = 
            new Dictionary<string, IConexao>();

        public static IConexao GetConexao(IAmbiente ambiente, 
            IConnectionFactory connectionFactory = null, 
            TipoConexao tipoConexao = TipoConexao.Ambiente)
        {
            var codigoAmbiente = ambiente.Codigo + "#" + tipoConexao.ToString() +
                (connectionFactory != null ? "#unityOfWork" : string.Empty);

            var conexao = _listaDeConexao.ContainsKey(codigoAmbiente) ? _listaDeConexao[codigoAmbiente] : null;
            if (conexao == null)
            {
                conexao = new Conexao(ambiente, connectionFactory ?? DataContextConnection.GetConnection(ambiente));
                _listaDeConexao[codigoAmbiente] = conexao;
            }

            return conexao;
        }
    }
}
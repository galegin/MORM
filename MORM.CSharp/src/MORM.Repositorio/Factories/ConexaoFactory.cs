﻿using MORM.CrossCutting;
using System.Collections.Generic;

namespace MORM.Repositorio
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
            TipoConexao tipoConexao = TipoConexao.Ambiente)
        {
            var codigoAmbiente = ambiente.Codigo + "#" + tipoConexao.ToString();

            var conexao = _listaDeConexao.ContainsKey(codigoAmbiente) ? _listaDeConexao[codigoAmbiente] : null;
            if (conexao == null)
            {
                conexao = new Conexao(ambiente);
                _listaDeConexao[codigoAmbiente] = conexao;
            }

            return conexao;
        }
    }
}
﻿using MORM.Dominio.Entidades;
using MORM.Dominio.Extensoes;
using MORM.Repositorio.Extensions;
using MORM.Repositorio.Interfaces;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Migrations
{
    public class MigracaoDatabase
    {
        #region constantes
        private const string _nomeEntidade = "_DATABASE";
        #endregion

        #region variaveis
        #endregion

        #region propriedades
        #endregion

        #region comandos
        #endregion

        #region contrutores
        #endregion

        #region metodos
        private static string GetVersaoModel(Type[] types)
        {
            var listaHash = new List<string>();

            foreach (var type in types)
                if (type.GetTabela() != null)
                    listaHash.Add(MigracaoEntidade.GetMd5(type));

            return string.Join(",", listaHash).GerarHashMd5();
        }

        public static bool IsGerarVersao(IAbstractDataContext context, Type[] types, out string versaoModel)
        {
            var versaoBase = context
                .GetObjetoF<Migracao>(f => $"{nameof(f.Codigo)} = '{_nomeEntidade}'")?.Versao;

            versaoModel = GetVersaoModel(types);

            return versaoModel.CompareTo(versaoBase) != 0;
        }

        public static void GravarVersao(IAbstractDataContext context, string versaoModel)
        {
            context.SetObjeto(new Migracao(_nomeEntidade, versaoModel));
        }
        #endregion
    }
}
﻿using MORM.Dominio.Entidades;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.Infra.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Infra.Data.Migrations
{
    public class MigracaoDatabase
    {
        #region constantes
        private const string _nomeEntidade = "_DATABASE";
        #endregion

        #region metodos
        private static string GetVersaoModel(Type[] types)
        {
            var listaHash = new List<string>();

            foreach (var type in types)
                if (type.GetTabela() != null)
                    listaHash.Add(Migracao.GetMd5(type));

            return string.Join(",", listaHash).GerarHashMd5();
        }

        public static bool IsGerarVersao(IAbstractDataContext context, Type[] types, out string versaoModel)
        {
            var versaoBase = context
                .GetObjetoF((MigracaoEnt f) => $"{nameof(f.Codigo)} = '{_nomeEntidade}'")?.Versao;

            versaoModel = GetVersaoModel(types);

            return versaoModel.CompareTo(versaoBase) != 0;
        }

        public static void GravarVersao(IAbstractDataContext context, string versaoModel)
        {
            context.SetObjeto(new MigracaoEnt(_nomeEntidade, versaoModel));
        }
        #endregion
    }
}
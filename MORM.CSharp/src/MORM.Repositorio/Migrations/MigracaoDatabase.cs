using MORM.Dominio.Entidades;
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.CrossCutting;
using System;
using System.Collections.Generic;

namespace MORM.Repositorio.Migrations
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

        public static bool IsGerarVersao(IMigracaoEntRepository repository, Type[] types, out string versaoModel)
        {
            var migracaoEnt = new MigracaoEnt { Codigo = _nomeEntidade };
            var versaoBase = repository.GetById(migracaoEnt)?.Versao;

            versaoModel = GetVersaoModel(types);

            return versaoModel.CompareTo(versaoBase) != 0;
        }

        public static void GravarVersao(IMigracaoEntRepository repository, string versaoModel)
        {
            repository.AddOrUpdate(new MigracaoEnt(_nomeEntidade, versaoModel));
        }
        #endregion
    }
}
using MORM.Dominio.Extensions;
using MORM.Dominio.Interfaces;
using MORM.CrossCutting;
using System;
using System.Configuration;
using System.Linq;

namespace MORM.Repositorio.Migrations
{
    public class MigracaoContexto
    {
        private static readonly bool _isMigracaoAuto;

        static MigracaoContexto()
        {
            _isMigracaoAuto = (ConfigurationManager.AppSettings[nameof(_isMigracaoAuto)] ?? "true") == "true";
        }

        public static void Gerar(IMigracaoEntRepository repository, IMigracao migracao)
        {
            if (repository == null)
                throw new ArgumentNullException(nameof(repository));

            var types = MigrationAssembly
                .GetTypes(filtro: (f) => f.GetTabela() != null)
                .ToArray();

            if (!MigracaoDatabase.IsGerarVersao(repository, types, out string versaoBase))
                return;

            migracao.Clear();

            types
                .ToList()
                .ForEach(type => migracao.CreateOrAlter(type));

            migracao.DropForeigns();
            migracao.CreateForeigns();

            MigracaoDatabase.GravarVersao(repository, versaoBase);
        }
    }
}
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

        public static void Gerar(IAbstractDataContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            var types = MigrationAssembly
                .GetTypes(filtro: (f) => f.GetTabela() != null)
                .ToArray();

            if (!MigracaoDatabase.IsGerarVersao(context, types, out string versaoBase))
                return;

            context.Migracao.Clear();

            types
                .ToList()
                .ForEach(type => context.Migracao.CreateOrAlter(type));

            context.Migracao.DropForeigns();
            context.Migracao.CreateForeigns();

            MigracaoDatabase.GravarVersao(context, versaoBase);
        }
    }
}
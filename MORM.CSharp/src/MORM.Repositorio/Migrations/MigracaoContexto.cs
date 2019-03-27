using MORM.Repositorio.Interfaces;
using MORM.Dominio.Extensoes;
using System;
using System.IO;
using System.Reflection;

namespace MORM.Repositorio.Migrations
{
    public class MigracaoContexto
    {
        public static void Gerar(IAbstractDataContext context, string package)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            if (!File.Exists(package))
                return;

            Assembly assembly = Assembly.LoadFile(package);

            Type[] types = assembly.GetTypes();

            if (!MigracaoDatabase.IsGerarVersao(context, types, out string versaoBase))
                return;

            context.Migracao.Clear();

            foreach (var type in types)
                if (type.GetTabela() != null)
                    context.Migracao.CreateOrAlter(type);

            context.Migracao.DropForeigns();
            context.Migracao.CreateForeigns();

            MigracaoDatabase.GravarVersao(context, versaoBase);
        }
    }
}
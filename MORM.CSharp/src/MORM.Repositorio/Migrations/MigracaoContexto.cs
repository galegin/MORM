using MORM.Repositorio.Interfaces;
using MORM.Utilidade.Extensoes;
using System;
using System.IO;
using System.Reflection;

namespace MORM.Repositorio.Migrations
{
    //-- galeg - 03/04/2018 19:54:24
    public class MigracaoContexto
    {
        public static void Gerar(IDataContext context, string package)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (package == null)
                throw new ArgumentNullException(nameof(package));

            if (!File.Exists(package))
                return;

            Assembly assembly = Assembly.LoadFile(package);

            Type[] types = assembly.GetTypes();

            context.Migracao.Clear();

            foreach (var type in types)
                if (type.GetTabela() != null)
                    context.Migracao.CreateOrAlter(type);

            context.Migracao.DropForeigns();
            context.Migracao.CreateForeigns();
        }
    }
}
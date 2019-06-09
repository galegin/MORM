﻿using MORM.Utils.Classes;
using System.Linq;

namespace MORM.Database.Extensions
{
    public static class PathExtensions
    {
        private const string _PATH = "PATH";

        public static void SetPath(this string caminho)
        {
            var conteudoPath = VariavelAmbiente.Pegar(_PATH);

            var conteudoLista = (conteudoPath.Contains(";") ? 
                conteudoPath.Split(';') : new string[] { conteudoPath })
                .ToList();

            if (!conteudoLista.Contains(caminho))
            {
                conteudoLista.Add(caminho);
                VariavelAmbiente.Setar(_PATH, string.Join(";", conteudoLista));
            }
        }
    }
}
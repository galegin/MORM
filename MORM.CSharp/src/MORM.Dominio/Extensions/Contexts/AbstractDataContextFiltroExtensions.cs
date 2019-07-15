using MORM.Dominio.Interfaces;
using MORM.Dominio.Tipagens;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace MORM.Dominio.Extensions
{
    public static class AbstractDataContextFiltroExtensions
    {
        private static bool _inFiltroPadrao =
            ConfigurationManager.AppSettings[nameof(_inFiltroPadrao)] == "true";
        private static bool _inValorPadrao =
            ConfigurationManager.AppSettings[nameof(_inValorPadrao)] == "true";

        public static void SetarFiltroPadraoO(this IAbstractDataContext context, object obj)
        {
            if (!_inFiltroPadrao)
                return;

            var filtroPadroes = obj.GetType().GetFiltroPadroes();

            foreach (var filtroPadrao in filtroPadroes)
            {
                var valor = context.GetValor(filtroPadrao);
                if (valor != null)
                    filtroPadrao.Prop.SetValue(obj, valor);
            }
        }

        public static void SetarFiltroPadraoW(this IAbstractDataContext context, Type type, ref string where)
        {
            if (!_inFiltroPadrao)
                return;

            var wherePadrao = new List<string>();

            if (!string.IsNullOrWhiteSpace(where))
                wherePadrao.Add(where);

            var filtroPadroes = type.GetFiltroPadroes();

            foreach (var filtroPadrao in filtroPadroes)
            {
                var valor = context.GetValor(filtroPadrao);
                if (valor != null)
                {
                    var valorStr = context.Ambiente.TipoDatabase.GetValueStr(valor);
                    wherePadrao.Add($"{filtroPadrao.Prop.Name} = {valorStr}");
                }
            }

            if (wherePadrao.Count > 0)
                where = string.Join(" and ", wherePadrao);
        }

        public static void SetarValorPadraoO(this IAbstractDataContext context, object obj)
        {
            if (!_inValorPadrao)
                return;

            var valorPadroes = obj.GetType().GetValorPadroes();

            foreach (var valorPadrao in valorPadroes)
            {
                var valor = context.GetValor(valorPadrao);
                if (valor != null)
                    valorPadrao.Prop.SetValue(obj, valor);
            }
        }

        public static void SetarValorPadraoW(this IAbstractDataContext context, Type type, ref string where)
        {
            if (!_inValorPadrao)
                return;

            var wherePadrao = new List<string>();

            if (!string.IsNullOrWhiteSpace(where))
                wherePadrao.Add(where);

            var valorPadroes = type.GetValorPadroes();

            foreach (var valorPadrao in valorPadroes)
            {
                var valor = context.GetValor(valorPadrao);
                if (valor != null)
                {
                    var valorStr = context.Ambiente.TipoDatabase.GetValueStr(valor);
                    wherePadrao.Add($"{valorPadrao.Prop.Name} = {valorStr}");
                }
            }

            if (wherePadrao.Count > 0)
                where = string.Join(" and ", wherePadrao);
        }
    }
}
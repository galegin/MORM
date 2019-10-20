using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public enum PesquisaTipo
    {
        Descricao,
        Listagem,
        Ambas,
    }

    public class PesquisaAttribute : Attribute
    {
        public PesquisaAttribute(Type classe, PesquisaTipo tipo, string campoDescricao = null, object ownerProp = null)
        {
            Classe = classe ?? throw new ArgumentNullException(nameof(classe));
            Tipo = tipo;
            if (IsDescricao)
                CampoDescricao = campoDescricao ?? throw new ArgumentNullException(nameof(campoDescricao));
            OwnerProp = ownerProp as PropertyInfo;
        }

        public Type Classe { get; }
        public PesquisaTipo Tipo { get; }
        public string CampoDescricao { get; }
        public PropertyInfo OwnerProp { get; }

        public bool IsDescricao => (Tipo != PesquisaTipo.Listagem);
        public bool IsListagem => (Tipo != PesquisaTipo.Descricao);
    }

    public static class PesquisaExtensions
    {
        public static bool IsCampoPesquisa(this PropertyInfo prop)
        {
            return prop.GetCustomAttributes(false).Any(a => a is PesquisaAttribute);
        }

        private static PesquisaAttribute GetClone(this PesquisaAttribute attr, PropertyInfo prop)
        {
            return new PesquisaAttribute(attr.Classe, attr.Tipo, attr.CampoDescricao, prop);
        }

        public static PesquisaAttribute GetCampoPesquisa(this PropertyInfo prop)
        {
            var attr = prop.GetAttribute<PesquisaAttribute>();
            return attr?.GetClone(prop);
        }
    }
}
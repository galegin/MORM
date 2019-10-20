using System;

namespace MORM.CrossCutting
{
    public class TabelaAttribute : Attribute
    {
        public TabelaAttribute(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
    }

    public static class TabelaExtensions
    {
        public static TabelaAttribute GetTabela(this Type type)
        {
            return type.GetAttribute<TabelaAttribute>();
        }

        public static TabelaAttribute GetTabela(this object obj)
        {
            return obj.GetType().GetTabela();
        }
    }
}
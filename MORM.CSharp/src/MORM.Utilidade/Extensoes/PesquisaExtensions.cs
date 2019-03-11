using MORM.Utilidade.Atributos;
using System.Linq;
using System.Reflection;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 16/07/2018 18:32:01
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
            var attr = (PesquisaAttribute)prop.GetCustomAttributes(false)
                .FirstOrDefault(a => a is PesquisaAttribute);
            return attr?.GetClone(prop);
        }
    }
}
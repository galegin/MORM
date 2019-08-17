using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{ 
    public class ValorTipagem
    {
        public Type ElementType { get; set; }
        public object Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public static class ValoresExtensions
    {
        public static IList GetValoresCampo(this PropertyInfo prop)
        {
            if (!prop.ReflectedType.IsEnum)
                return null;

            IList retorno = new List<ValorTipagem>();

            foreach (var value in Enum.GetValues(prop.ReflectedType))
            {
                retorno.Add(new ValorTipagem
                {
                    ElementType = prop.ReflectedType,
                    Codigo = value,
                    Descricao = value.ToString()
                });
            }

            return retorno;
        }

        public static bool IsValoresCampo(this PropertyInfo prop)
        {
            return prop.GetValoresCampo() != null;
        }
    }
}
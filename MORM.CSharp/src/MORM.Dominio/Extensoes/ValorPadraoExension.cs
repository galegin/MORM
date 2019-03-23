using MORM.Dominio.Atributos;
using System;
using System.Reflection;

namespace MORM.Dominio.Extensoes
{
    public static class ValorPadraoExension
    {
        //-- valor padrao

        private static ValorPadraoAttribute GetClone(this ValorPadraoAttribute valor, PropertyInfo prop)
        {
            return new ValorPadraoAttribute(valor.Tipo, valor.Valor, prop);
        }

        public static ValorPadroes GetValorPadroes(this Type type)
        {
            var valorPadroes = new ValorPadroes();
            foreach (var prop in type.GetProperties())
                foreach (var attr in prop.GetCustomAttributes(false))
                    if (attr.GetType() == typeof(ValorPadraoAttribute))
                        valorPadroes.Add((attr as ValorPadraoAttribute).GetClone(prop));
            return valorPadroes;
        }
        
        //-- filtro padrao

        private static FiltroPadraoAttribute GetClone(this FiltroPadraoAttribute filtro, PropertyInfo prop)
        {
            return new FiltroPadraoAttribute(filtro.Tipo, filtro.Valor, prop);
        }

        public static FiltroPadroes GetFiltroPadroes(this Type type)
        {
            var filtroPadroes = new FiltroPadroes();
            foreach (var prop in type.GetProperties())
                foreach (var attr in prop.GetCustomAttributes(false))
                    if (attr.GetType() == typeof(FiltroPadraoAttribute))
                        filtroPadroes.Add((attr as FiltroPadraoAttribute).GetClone(prop));
            return filtroPadroes;
        }
    }
}
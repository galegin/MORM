using MORM.Dominio.Atributos;
using MORM.CrossCutting;
using System;
using System.Linq;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class ValorPadraoExensions
    {
        //-- valor padrao

        private static ValorPadraoAttribute GetClone(this ValorPadraoAttribute valor, PropertyInfo prop)
        {
            return new ValorPadraoAttribute(valor.Tipo, valor.Valor, prop);
        }

        public static ValorPadroes GetValorPadroes(this Type type)
        {
            var valorPadroes = new ValorPadroes();

            type
                .GetProperties()
                .ToList()
                .ForEach(prop =>
                {
                    var valorPadrao = prop.GetAttribute<ValorPadraoAttribute>()?.GetClone(prop);
                    if (valorPadrao != null)
                        valorPadroes.Add(valorPadrao);
                });

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

            type
                .GetProperties()
                .ToList()
                .ForEach(prop =>
                {
                    var filtoPadrao = prop.GetAttribute<FiltroPadraoAttribute>().GetClone(prop);
                    if (filtoPadrao != null)
                        filtroPadroes.Add(filtoPadrao);
                });

            return filtroPadroes;
        }
    }
}
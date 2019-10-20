using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public enum ValorPadraoTipo
    {
        EmpresaLogada,
        UsuarioLogado,
        TerminalLogado,
        DataSistema,
        HoraSistema,
        ValorPadrao
    }

    public class ValorPadraoAttribute : Attribute
    {
        public ValorPadraoAttribute(ValorPadraoTipo tipo)
        {
            Tipo = tipo;
        }

        public ValorPadraoAttribute(ValorPadraoTipo tipo, object valor) : this(tipo)
        {
            Valor = valor;
        }

        public ValorPadraoAttribute(ValorPadraoTipo tipo, object valor, PropertyInfo prop) : this(tipo, valor)
        {
            Prop = prop;
        }

        public ValorPadraoTipo Tipo { get; }
        public object Valor { get; }
        public PropertyInfo Prop { get; }
    }

    public class ValorPadroes : List<ValorPadraoAttribute> { }

    public class FiltroPadraoAttribute : ValorPadraoAttribute
    {
        public FiltroPadraoAttribute(ValorPadraoTipo tipo) : base(tipo)
        {
        }

        public FiltroPadraoAttribute(ValorPadraoTipo tipo, object valor) : base(tipo, valor)
        {
        }

        public FiltroPadraoAttribute(ValorPadraoTipo tipo, object valor, PropertyInfo prop) : base(tipo, valor, prop)
        {
        }
    }

    public class FiltroPadroes : List<FiltroPadraoAttribute> { }

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
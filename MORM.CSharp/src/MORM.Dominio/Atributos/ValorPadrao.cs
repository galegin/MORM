using MORM.Dominio.Tipagens;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MORM.Dominio.Atributos
{
    public class ValorPadraoAttribute : Attribute
    {
        public ValorPadraoAttribute(TipoValorPadrao tipo)
        {
            Tipo = tipo;
        }

        public ValorPadraoAttribute(TipoValorPadrao tipo, object valor) : this(tipo)
        {
            Valor = valor;
        }

        public ValorPadraoAttribute(TipoValorPadrao tipo, object valor, PropertyInfo prop) : this(tipo, valor)
        {
            Prop = prop;
        }

        public TipoValorPadrao Tipo { get; }
        public object Valor { get; }
        public PropertyInfo Prop { get; }
    }

    public class ValorPadroes : List<ValorPadraoAttribute> { }

    public class FiltroPadraoAttribute : ValorPadraoAttribute
    {
        public FiltroPadraoAttribute(TipoValorPadrao tipo) : base(tipo)
        {
        }

        public FiltroPadraoAttribute(TipoValorPadrao tipo, object valor) : base(tipo, valor)
        {
        }

        public FiltroPadraoAttribute(TipoValorPadrao tipo, object valor, PropertyInfo prop) : base(tipo, valor, prop)
        {
        }
    }

    public class FiltroPadroes : List<FiltroPadraoAttribute> { }
}
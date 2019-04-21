using System;

namespace MORM.Dominio.Atributos
{
    public class DescricaoAttribute : Attribute
    {
        public DescricaoAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }

    public class TamanhoAttribute : Attribute
    {
        public TamanhoAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class PrecisaoAttribute : Attribute
    {
        public PrecisaoAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
using System;

namespace MORM.Dominio.Atributos
{
    public class FormatoAttribute : Attribute
    {
        public FormatoAttribute(string conteudo, string validacao)
        {
            Conteudo = conteudo ?? throw new ArgumentNullException(nameof(conteudo));
            Validacao = validacao ?? throw new ArgumentNullException(nameof(validacao));
        }

        public FormatoAttribute(string conteudo) : this(conteudo, string.Empty)
        {
        }

        public string Conteudo { get; private set; }
        public string Validacao { get; private set; }
    }
}
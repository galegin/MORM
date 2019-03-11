using System;

namespace MORM.Utilidade.Atributos
{
    public class FormatoAttribute : Attribute
    {
        public FormatoAttribute(string conteudo, string validacao)
        {
            Conteudo = conteudo ?? throw new ArgumentNullException(nameof(conteudo));
            Validacao = validacao ?? throw new ArgumentNullException(nameof(validacao));
        }

        public string Conteudo { get; private set; }
        public string Validacao { get; private set; }
    }
}
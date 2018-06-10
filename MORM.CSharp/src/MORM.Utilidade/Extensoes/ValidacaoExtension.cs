using MORM.Utilidade.Atributos;
using System;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 28/01/2018 10:28:17
    public static class ValidacaoExtension
    {
        //-- validacao

        public static ValidacaoCampo GetValidacao(this Type type)
        {
            ValidacaoCampo relacao = null;
            foreach (var attr in type.GetCustomAttributes(false))
                if (attr.GetType() == typeof(ValidacaoCampo))
                    relacao = (attr as ValidacaoCampo);
            return relacao;
        }

        public static void ValidarCampos(this object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                var validacao = prop.GetType().GetValidacao();
                if (validacao != null)
                {
                    var value = prop.GetValue(obj);
                    validacao.Validacao.Validar(value);
                }
            }
        }
    }
}
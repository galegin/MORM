using MORM.Utilidade.Atributos;
using MORM.Utilidade.Utils;
using System;
using System.Reflection;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 28/01/2018 10:28:17
    public static class ValidacaoExtension
    {
        //-- validacao

        public static ValidacaoCampo GetValidacao(this PropertyInfo prop)
        {
            ValidacaoCampo validacao = null;
            foreach (var attr in prop.GetCustomAttributes(false))
                if (attr.GetType() == typeof(ValidacaoCampo))
                    validacao = (attr as ValidacaoCampo);
            return validacao;
        }

        public static void ValidarCampos(this object obj)
        {
            if (obj == null)
                return;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var validacao = prop.GetValidacao();
                if (validacao != null)
                {
                    try
                    {
                        var value = prop.GetValue(obj);
                        if (value != null)
                            validacao.Validacao?.Validar(value);
                    }
                    catch (Exception ex)
                    {
                        Logger.ErroException(ex, "Entidade: " + obj.GetType().Name + " / Campo : " + prop.Name);
                        throw;
                    }
                }
            }
        }
    }
}
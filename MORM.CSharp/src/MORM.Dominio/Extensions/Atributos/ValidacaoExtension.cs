using MORM.Dominio.Atributos;
using System;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
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
                        //Logger.ErroException(ex, "Entidade: " + obj.GetType().Name + " / Campo : " + prop.Name);
                        throw ex;
                    }
                }
            }
        }
    }
}
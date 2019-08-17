using MORM.Dominio.Atributos;
using MORM.Infra.CrossCutting;
using System;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class ValidacaoExtensions
    {
        //-- validacao

        public static ValidacaoCampo GetValidacao(this PropertyInfo prop)
        {
            return prop.GetAttribute<ValidacaoCampo>();
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
                        Logger.Erro($"Entidade: {obj.GetType().Name} / Campo: {prop.Name}", ex: ex);
                        throw ex;
                    }
                }
            }
        }
    }
}
using MORM.Dominio.Atributos;
using MORM.Infra.CrossCutting;
using System;
using System.Linq;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class TipagemExtension
    {
        //-- validacao

        public static TipagemCampo GetTipagemCampo(this PropertyInfo prop)
        {
            return prop.GetCustomAttributes(false)
                .ToList()
                .Where(attr => attr.GetType() == typeof(TipagemCampo))
                .ToList()
                .ConvertAll(attr => (TipagemCampo)attr)
                .FirstOrDefault()
                ;
        }

        public static void ValidarTipagens(this object obj)
        {
            if (obj == null)
                return;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var tipagemCampo = prop.GetTipagemCampo();
                if (tipagemCampo != null)
                {
                    try
                    {
                        var value = prop.GetValue(obj);
                        if (value != null)
                        {
                            var lista = TipagemCampoItems.GetTipagemCampoItems(tipagemCampo.Tipagens);
                            if (lista.Any(x => x.Codigo == value.ToString()) == false)
                                throw new Exception($"O valor {value} nao esta contido na lista {lista.ToString()}");
                        }
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
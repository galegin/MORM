using MORM.Dominio.Atributos;
using System;
using System.Linq;
using System.Reflection;

namespace MORM.Dominio.Extensoes
{
    public static class TipagemExtension
    {
        //-- validacao

        public static TipagemCampo GetTipagemCampo(this PropertyInfo prop)
        {
            TipagemCampo tipagemCampo = null;
            foreach (var attr in prop.GetCustomAttributes(false))
                if (attr.GetType() == typeof(TipagemCampo))
                    tipagemCampo = (attr as TipagemCampo);
            return tipagemCampo;
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
                        //Logger.ErroException(ex, "Entidade: " + obj.GetType().Name + " / Campo : " + prop.Name);
                        throw ex;
                    }
                }
            }
        }
    }
}
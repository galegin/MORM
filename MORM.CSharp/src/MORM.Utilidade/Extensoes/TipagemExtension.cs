using MORM.Utilidade.Atributos;
using System;
using System.Linq;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 28/01/2018 11:29:00
    public static class TipagemExtension
    {
        //-- validacao

        public static TipagemCampo GetTipagemCampo(this Type type)
        {
            TipagemCampo tipagemCampo = null;
            foreach (var attr in type.GetCustomAttributes(false))
                if (attr.GetType() == typeof(TipagemCampo))
                    tipagemCampo = (attr as TipagemCampo);
            return tipagemCampo;
        }

        public static void ValidarTipagens(this object obj)
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                var tipagemCampo = prop.GetType().GetTipagemCampo();
                if (tipagemCampo != null)
                {
                    var value = prop.GetValue(obj);
                    var lista = TipagemCampoItems.GetTipagemCampoItems(tipagemCampo.Tipagens);
                    if (lista.Any(x => x.Codigo == value.ToString()) == false)
                        throw new Exception($"O valor {value} nao esta contido na lista {lista.ToString()}");
                }
            }
        }
    }
}
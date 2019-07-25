using MORM.Dominio.Extensions;
using System;
using System.Collections;
using System.Linq;

namespace MORM.Infra.CrossCutting
{
    public class ObjetoMapper
    {
        public static object GetObjetoRetorno(Type type, object objeto)
        {
            var objetoRetorno = Activator.CreateInstance(type);
            if (objeto is IList)
                SetListaRetorno(objeto as IList, objetoRetorno as IList);
            else
                SetObjetoRetorno(objeto, objetoRetorno);
            return objetoRetorno;
        }

        public static TRetorno GetObjetoRetorno<TRetorno>(object objeto)
        {
            return (TRetorno)GetObjetoRetorno(typeof(TRetorno), objeto);
        }

        private static void SetObjetoRetorno(object objeto, object objetoRetorno)
        {
            objetoRetorno.CloneInstancePropOrFieldAll(objeto);
        }

        private static void SetListaRetorno(IList lista, IList listaRetorno)
        {
            var type = listaRetorno.GetType().GetGenericArguments().Single();

            foreach (var objeto in lista)
            {
                var objetoRetorno = Activator.CreateInstance(type);
                SetObjetoRetorno(objeto, objetoRetorno);
                listaRetorno.Add(objetoRetorno);
            }
        }
    }
}
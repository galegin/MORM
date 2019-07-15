using System;
using System.Collections.Generic;

namespace MORM.Infra.CrossCutting
{
    public class SingletonFactory
    {
        private static Dictionary<Type, object> _listaDeInstance =
            new Dictionary<Type, object>();

        public static TObject GetInstance<TObject>(params object[] objeto) where TObject : class
        {
            TObject instance =
                _listaDeInstance.ContainsKey(typeof(TObject)) ? (TObject)_listaDeInstance[typeof(TObject)] : null;

            if (instance == null)
            {
                if (objeto != null)
                    instance = (TObject)Activator.CreateInstance(typeof(TObject), objeto);
                else
                    instance = Activator.CreateInstance<TObject>();

                _listaDeInstance[typeof(TObject)] = instance;
            }

            return instance;
        }

        public static TObject GetInstance<TObject>() where TObject : class
        {
            return GetInstance<TObject>(null);
        }
    }
}
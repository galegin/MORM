using MORM.Dominio.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ClasseExecute
    {
        public static object Execute(object objeto, string metodo, params object[] parametros)
        {
            var metodoInvoke = objeto.GetType().GetMethod(metodo);
            var metodoParameters = metodoInvoke.GetParameters();
            var metodoValues = new List<object>();

            int index = 0;
            foreach (var parameter in metodoParameters)
            {
                var parameterType = parameter.ParameterType;
                var parameterObjeto = Activator.CreateInstance(parameterType);
                parameterObjeto.CloneInstancePropOrFieldAll(parametros[index]);
                metodoValues.Add(parameterObjeto);
                index++;
            }

            return metodoInvoke?.Invoke(objeto, metodoValues.ToArray());
        }

        public static object Execute(Type type, string metodo, params object[] parametros)
        {
            var objeto = Activator.CreateInstance(type);
            return Execute(objeto, metodo, parametros);
        }

        public static object Execute(string typeName, string metodo, params object[] parametros)
        {
            var type = Assembly.GetExecutingAssembly().GetType(typeName);
            return Execute(type, metodo, parametros);
        }
    }
}
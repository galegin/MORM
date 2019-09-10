using System;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class ObjetoExecute
    {
        public static object Execute(object objeto, string metodo, params object[] parametros)
        {
            return MetodoExecute.Execute(objeto.GetType(), objeto, metodo, parametros);
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
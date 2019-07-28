using System;
using System.Reflection;

namespace MORM.Infra.CrossCutting
{
    public class ClasseExecute
    {
        public static object Execute(Type type, string metodo, params object[] parametros)
        {
            return MetodoExecute.Execute(type, null, metodo, parametros);
        }

        public static object Execute(string typeName, string metodo, params object[] parametros)
        {
            var type = Assembly.GetExecutingAssembly().GetType(typeName);
            return Execute(type, metodo, parametros);
        }
    }
}
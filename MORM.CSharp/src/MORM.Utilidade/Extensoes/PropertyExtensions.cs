using System;
using System.Reflection;

namespace MORM.Utilidade.Extensoes
{
    //-- galeg - 13/10/2018 15:04:12
    public static class PropertyExtensions
    {
        private static BindingFlags _bindFlags = 
            BindingFlags.Instance | 
            BindingFlags.Public | 
            BindingFlags.NonPublic | 
            BindingFlags.Static;
        // get

        public static object GetInstanceProp(this Type type, object instance, string propName)
        {
            PropertyInfo prop = type.GetProperty(propName, _bindFlags);
            return prop?.GetValue(instance);
        }

        public static object GetInstanceProp(this object instance, string propName)
        {
            return instance.GetType().GetInstanceProp(instance, propName);
        }

        // set

        public static void SetInstanceProp(this Type type, object instance, string propName, object value)
        {
            PropertyInfo prop = type.GetProperty(propName, _bindFlags);
            prop?.SetValue(instance, value);
        }

        public static void SetInstanceProp(this object instance, string propName, object value)
        {
            instance.GetType().SetInstanceProp(instance, propName, value);
        }

        // clear

        public static void ClearInstanceProp(this Type type, object instance, string propName)
        {
            PropertyInfo prop = type.GetProperty(propName, _bindFlags);
            var propNull = prop.PropertyType.GetValueNull();
            instance.SetInstanceProp(propName, propNull);
        }

        public static void ClearInstanceProp(this object instance, string propName)
        {
            instance.GetType().ClearInstanceProp(instance, propName);
        }

        public static void ClearInstancePropAll(this Type type, object instance)
        {
            PropertyInfo[] props = type.GetProperties(_bindFlags);
            foreach (var prop in props)
                instance.GetType().ClearInstanceProp(instance, prop.Name);
        }

        public static void ClearInstancePropAll(this object instance)
        {
            instance.GetType().ClearInstancePropAll(instance);
        }
    }
}
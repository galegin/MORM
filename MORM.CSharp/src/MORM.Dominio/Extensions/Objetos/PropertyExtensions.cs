using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class PropertyExtensions
    {
        // flags

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

        // clone

        public static void CloneInstanceProp(this Type type, object instance, string propName, object instanceClone)
        {
            var value = instanceClone.GetInstancePropOrField(propName);
            instance.SetInstanceProp(propName, value);
        }

        public static void CloneInstanceProp(this object instance, string propName, object instanceClone)
        {
            instance.GetType().CloneInstanceProp(instance, propName, instanceClone);
        }

        public static void CloneInstancePropAll(this Type type, object instance, object instanceClone)
        {
            foreach (var prop in type.GetProperties(_bindFlags))
                instance.CloneInstanceProp(prop.Name, instanceClone);
        }

        public static void CloneInstancePropAll(this object instance, object instanceClone)
        {
            instance.GetType().CloneInstancePropAll(instance, instanceClone);
        }

        // atribute

        public static TAttr GetAttribute<TAttr>(this PropertyInfo prop)
        {
            return (TAttr)prop
                .GetCustomAttributes(false)
                .FirstOrDefault(x => x.GetType() == typeof(TAttr));
        }

        // data annotation

        public static DescriptionAttribute GetDescription(this PropertyInfo prop)
        {
            return prop.GetAttribute<DescriptionAttribute>();
        }

        public static StringLengthAttribute GetStringLength(this PropertyInfo prop)
        {
            return prop.GetAttribute<StringLengthAttribute>();
        }
    }
}
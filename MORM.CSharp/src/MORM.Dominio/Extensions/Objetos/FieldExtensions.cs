using System;
using System.Reflection;

namespace MORM.Dominio.Extensions
{
    public static class FieldExtensions
    {
        // flags

        private static BindingFlags _bindFlags = 
            BindingFlags.Instance | 
            BindingFlags.Public | 
            BindingFlags.NonPublic |
            BindingFlags.Static;

        // get

        public static object GetInstanceField(this Type type, object instance, string fieldName)
        {
            FieldInfo field = type.GetField(fieldName, _bindFlags);
            return field?.GetValue(instance);
        }

        public static object GetInstanceField(this object instance, string fieldName)
        {
            return instance.GetType().GetInstanceField(instance, fieldName);
        }

        // set

        public static void SetInstanceField(this Type type, object instance, string fieldName, object value)
        {
            FieldInfo field = type.GetField(fieldName, _bindFlags);
            field?.SetValue(instance, value);
        }

        public static void SetInstanceField(this object instance, string fieldName, object value)
        {
            instance.GetType().SetInstanceField(instance, fieldName, value);
        }

        // clear

        public static void ClearInstanceField(this Type type, object instance, string fieldName)
        {
            FieldInfo field = type.GetField(fieldName, _bindFlags);
            var fieldNull = field.FieldType.GetValueNull();
            instance.SetInstanceField(fieldName, fieldNull);
        }

        public static void ClearInstanceField(this object instance, string fieldName)
        {
            instance.GetType().ClearInstanceField(instance, fieldName);
        }

        public static void ClearInstanceFieldAll(this Type type, object instance)
        {
            FieldInfo[] fields = type.GetFields(_bindFlags);
            foreach (var field in fields)
                instance.GetType().ClearInstanceField(instance, field.Name);
        }

        public static void ClearInstanceFieldAll(this object instance)
        {
            instance.GetType().ClearInstanceFieldAll(instance);
        }

        // clone

        public static void CloneInstanceField(this Type type, object instance, string fieldName, object instanceClone)
        {
            FieldInfo field = type.GetField(fieldName, _bindFlags);
            var value = field.GetValue(instanceClone);
            instance.SetInstanceField(fieldName, value);
        }

        public static void CloneInstanceField(this object instance, string fieldName, object instanceClone)
        {
            instance.GetType().CloneInstanceField(instance, fieldName, instanceClone);
        }

        public static void CloneInstanceFieldAll(this Type type, object instance, object instanceClone)
        {
            FieldInfo[] fields = type.GetFields(_bindFlags);
            foreach (var field in fields)
                instance.GetType().CloneInstanceField(instance, field.Name, instanceClone);
        }

        public static void CloneInstanceFieldAll(this object instance, object instanceClone)
        {
            instance.GetType().CloneInstanceFieldAll(instance, instanceClone);
        }
    }
}
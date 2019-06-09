using System;

namespace MORM.Dominio.Extensoes
{
    public static class ObjectExtensions
    {
        // get

        public static object GetInstancePropOrField(this Type type, object instance, string name)
        {
            return type.GetInstanceProp(instance, name) ?? type.GetInstanceField(instance, name);
        }

        public static object GetInstancePropOrField(this object instance, string name)
        {
            return instance.GetType().GetInstancePropOrField(instance, name);
        }

        // set

        public static void SetInstancePropOrField(this Type type, object instance, string name, object value)
        {
            if (type.GetProperty(name) != null)
                type.SetInstanceProp(instance, name, value);
            else
                type.SetInstanceField(instance, name, value);
        }

        public static void SetInstancePropOrField(this object instance, string name, object value)
        {
            instance.GetType().SetInstancePropOrField(instance, name, value);
        }

        // clear

        public static void ClearInstancePropOrField(this Type type, object instance, string name)
        {
            if (type.GetProperty(name) != null)
                type.ClearInstanceProp(instance, name);
            else
                type.ClearInstanceField(instance, name);
        }

        public static void ClearInstancePropOrField(this object instance, string name)
        {
            instance.GetType().ClearInstancePropOrField(instance, name);
        }

        public static void ClearInstancePropOrFieldAll(this Type type, object instance, bool isProp = true)
        {
            if (isProp)
                type.ClearInstancePropAll(instance);
            else
                type.ClearInstanceFieldAll(instance);
        }

        public static void ClearInstancePropOrFieldAll(this object instance, bool isProp = true)
        {
            instance.GetType().ClearInstancePropOrFieldAll(instance, isProp);
        }

        // clone

        public static void CloneInstancePropOrField(this Type type, object instance, string name, object instanceClone)
        {
            if (type.GetProperty(name) != null)
                type.CloneInstanceProp(instance, name, instanceClone);
            else
                type.CloneInstanceField(instance, name, instanceClone);
        }

        public static void CloneInstancePropOrField(this object instance, string name, object instanceClone)
        {
            instance.GetType().CloneInstancePropOrField(instance, name, instanceClone);
        }

        public static void CloneInstancePropOrFieldAll(this Type type, object instance, object instanceClone, bool isProp = true)
        {
            if (isProp)
                type.CloneInstancePropAll(instance, instanceClone);
            else
                type.CloneInstanceFieldAll(instance, instanceClone);
        }

        public static void CloneInstancePropOrFieldAll(this object instance, object instanceClone, bool isProp = true)
        {
            if (instanceClone != null)
                instance.GetType().CloneInstancePropOrFieldAll(instance, instanceClone, isProp);
        }
    }
}
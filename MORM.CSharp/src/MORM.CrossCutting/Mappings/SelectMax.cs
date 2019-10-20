using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class SelectMaxAttribute : Attribute
    {
    }

    public static class SelectMaxExtensions
    {
        public static SelectMaxAttribute GetSelectMax(this PropertyInfo prop)
        {
            return prop.GetAttribute<SelectMaxAttribute>();
        }

        public static PropertyInfo GetCampoSelectMax(this Type type)
        {
            return type.GetProperties()
                .FirstOrDefault(prop => prop.GetSelectMax() != null)
                ;
        }
    }
}
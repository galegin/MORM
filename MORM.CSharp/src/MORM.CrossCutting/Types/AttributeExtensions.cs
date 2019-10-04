using System;
using System.Linq;
using System.Reflection;

namespace MORM.CrossCutting
{
    public static class AttributeExtensions
    {
        #region metodos

        #region property

        public static T GetAttributeProp<T>(this PropertyInfo property) where T : Attribute
        {
            var attrs = property
                .GetCustomAttributes(typeof(T), false)
                .FirstOrDefault();

            if (attrs != null)
                return (T)attrs;

            return null;
        }

        #endregion 

        #region field

        public static T GetAttributeField<T>(this FieldInfo field) where T : Attribute
        {
            var attrs = field
                .GetCustomAttributes(typeof(T), false)
                .FirstOrDefault();

            if (attrs != null)
                return (T)attrs;

            return null;
        }

        #endregion 

        #region type

        public static T GetAttributeType<T>(this Type type) where T : Attribute
        {
            var attrs = type
                .GetCustomAttributes(typeof(T), false)
                .FirstOrDefault();

            if (attrs != null)
                return (T)attrs;

            return null;
        }

        #endregion 

        #region enum

        public static T GetAttributeEnum<T>(this Enum enun) where T : Attribute
        {
            var type = enun.GetType();
            var memInfo = type.GetMember(enun.ToString());
            var attrs = memInfo.FirstOrDefault()?
                .GetCustomAttributes(typeof(T), false)
                .FirstOrDefault();

            return (T)attrs;
        }

        #endregion 

        #endregion 
    }
}
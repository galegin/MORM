using System;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class CampoCompAttribute : Attribute
    {
        #region propriedades
        public Type ElementType { get; private set; }
        #endregion

        #region construtores
        public CampoCompAttribute(Type elementType)
        {
            ElementType = elementType ?? throw new ArgumentNullException(nameof(elementType));
        }
        #endregion
    }

    public static class CampoCompTipoExtensions
    {
        public static CampoCompAttribute GetCampoComp(this PropertyInfo prop)
        {
            return prop.GetAttribute<CampoCompAttribute>();
        }
    }
}
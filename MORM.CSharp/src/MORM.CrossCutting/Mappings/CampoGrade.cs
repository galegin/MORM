using System;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class CampoGradeAttribute : Attribute
    {
        #region propriedades
        public Type ElementType { get; private set; }
        #endregion

        #region construtores
        public CampoGradeAttribute(Type elementType)
        {
            ElementType = elementType ?? throw new ArgumentNullException(nameof(elementType));
        }
        #endregion
    }

    public static class CampoGradeTipoExtensions
    {
        public static CampoGradeAttribute GetCampoGrade(this PropertyInfo prop)
        {
            return prop.GetAttribute<CampoGradeAttribute>();
        }
    }
}
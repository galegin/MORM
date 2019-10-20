using System;
using System.Reflection;

namespace MORM.CrossCutting
{
    public class CampoMemoAttribute : Attribute
    {
        #region propriedades
        public double Altura { get; private set; }
        public double Largura { get; private set; }
        #endregion

        #region construtores
        public CampoMemoAttribute(double altura = 0, double largura = 0)
        {
            Altura = altura;
            Largura = largura;
        }
        #endregion
    }

    public static class CampoMemoTipoExtensions
    {
        public static CampoMemoAttribute GetCampoMemo(this PropertyInfo prop)
        {
            return prop.GetAttribute<CampoMemoAttribute>();
        }
    }
}
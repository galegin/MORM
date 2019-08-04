using System.Reflection;

namespace MORM.Apresentacao.Views
{
    public static class TipoCampoExtensions
    {
        public static bool IsKey(this PropertyInfo prop)
        {
            return prop.GetMetadataProp().Tipo.IsKey();
        }

        public static bool IsReq(this PropertyInfo prop)
        {
            return prop.GetMetadataProp().Tipo.IsReq();
        }
    }
}